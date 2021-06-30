using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class HealthCheckController : ControllerBase
    {
       [HttpGet("ping")]
       public string Ping()
        {
            return "pong";
        }
    }
}
