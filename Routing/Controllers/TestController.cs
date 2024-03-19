using Microsoft.AspNetCore.Mvc;

namespace Routing.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        public IActionResult GetUser(string a)
        {
            return Ok($"GetUser 1");
        }

        [HttpGet]
        [Route("")]
        public IActionResult GetUser(string a, string? b)
        {
            return Ok($"GetUser 2");
        }
    }
}
