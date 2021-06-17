using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1")]
    public abstract class ApiController : ControllerBase
    {
       [HttpGet("ping")]
       public string Ping()
        {
            return "pong";
        }
    }
}
