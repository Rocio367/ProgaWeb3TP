using GestorDePedidos.Entidades;
using Repositorios.Filtros.FiltrosUsuarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorios
{
    public class RepositorioUsuario : IRepositorioUsuario
    {

        private _20211CTPContext _contexto;
        public RepositorioUsuario(_20211CTPContext contexto)
        {
            _contexto = contexto;
        }
        public void Guardar(Usuario usuario)
        {
            _contexto.Usuarios.Add(usuario);
            _contexto.SaveChanges();
        }

        public Usuario ObtenerUsuario(int id)
        {
            return _contexto.Usuarios.Find(id);
        }
        public Usuario ObtenerUsuarioPorMail(string mail)
        {
            List<Usuario> listUsuario = _contexto.Usuarios.ToList();
            Usuario user = listUsuario.Find(x => x.Email == mail);
            if (user != null)
            {
                return user;
            }
            else
            {
                return null;
            }
        }
        public void EditarUsuario(Usuario usuario)
        {
            Usuario actual = _contexto.Usuarios.Find(usuario.IdUsuario);
            actual.Nombre = usuario.Nombre;
            actual.EsAdmin = usuario.EsAdmin;
            actual.Apellido = usuario.Apellido;
            actual.Email = usuario.Email;
            actual.Password = usuario.Password;
            actual.FechaNacimiento = usuario.FechaNacimiento;
            actual.FechaModificacion = DateTime.Now;

            _contexto.SaveChanges();
        }

        public List<Usuario> ObtenerUsuarios()
        {
            return _contexto.Usuarios.ToList();
        }
        public void EliminarUsuario(Usuario usuario)
        {
            Usuario actual = _contexto.Usuarios.Find(usuario.IdUsuario);
            actual.FechaBorrado = DateTime.Now;
            _contexto.SaveChanges();
        }

        public bool ValidarLogin(Usuario usuario)
        {
            List<Usuario> listUsuario = _contexto.Usuarios.ToList();
            Usuario user = listUsuario.Find(x => x.Email == usuario.Email && x.Password == usuario.Password);
            return user != null;
        }

        public void EditarHora(string email)
        {
            List<Usuario> listUsuario = _contexto.Usuarios.ToList();
            Usuario user = listUsuario.Find(x => x.Email == email);
            if (user != null)
            {
                user.FechaUltLogin = DateTime.Now;

                _contexto.SaveChanges();
            }
        }

        public List<Usuario> ObtenerUsuariosPorFiltro(IFiltroUsuario filtro)
        {
            var resultado = _contexto.Usuarios.Where(filtro.Evaluar).Select(usuario => usuario);
            return resultado.ToList();
        }

        public List<Usuario> ObtenerUsuariosParaFiltro()
        {
            List<Usuario> resultados = new List<Usuario>();
            List<Usuario> resultadosBD = _contexto.Usuarios.Where(e => e.FechaBorrado == null).ToList();
            resultadosBD.ForEach(e =>
            {
                resultados.Add(e);
            });
            return resultados;
        }

        public int ContarUsuariosConMail(string mail)
        {
           return _contexto.Usuarios.Where(u => u.FechaBorrado == null && u.Email.Equals(mail)).Count();
        }
    }
}