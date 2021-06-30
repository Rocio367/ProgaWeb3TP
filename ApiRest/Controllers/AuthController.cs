using ApiRest.Modelo;
using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace ApiRest.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private _20211CTPContext _contexto;
        private IConfiguration _configuration;

        public AuthController(_20211CTPContext context, IConfiguration configuration)
        {
            _contexto = context;
            _configuration = configuration;
        }

        [HttpPost("login")]
        public ActionResult Autenticar(LoginRequest loginRequest)
        {
            if (string.IsNullOrWhiteSpace(loginRequest.Email) || string.IsNullOrWhiteSpace(loginRequest.Password))
            {
                return BadRequest();
            }

            Usuario usuario = null;

            try
            {
                usuario = _contexto.Usuarios.Where(u => u.Email.Equals(loginRequest.Email)
                                                        && u.Password.Equals(loginRequest.Password)).Single();
            }
            catch (Exception e)
            {
                return NotFound();
            }

            return ResponderUsuarioLogueado(usuario);
        }

        private OkObjectResult ResponderUsuarioLogueado(Usuario usuario)
        {            
            LoginResponse respuesta = new LoginResponse
            {
                Nombre = usuario.Nombre,
                Apellido = usuario.Apellido,
                Email = usuario.Email,
                IdUsuario = usuario.IdUsuario,
                FechaNacimiento = usuario.FechaNacimiento.Value.ToString("yyyy-MM-dd"),
                Token = GenerarToken(usuario)
            };

            return Ok(respuesta);
        }

        private string GenerarToken(Usuario usuario)
        {
            string secretKey = _configuration.GetValue<string>("SecretKey");
            byte[] key = Encoding.ASCII.GetBytes(secretKey);

            string rol = usuario.EsAdmin ? "Admin" : "Usuario";

            ClaimsIdentity claims = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Email, usuario.Email),
                new Claim(ClaimTypes.Role, rol)
            });            

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,                
                Expires = DateTime.UtcNow.AddDays(1),                
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
