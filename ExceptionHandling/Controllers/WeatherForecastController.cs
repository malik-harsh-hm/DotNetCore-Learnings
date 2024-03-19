using Microsoft.AspNetCore.Mvc;

namespace ExceptionHandling.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            throw new Exception("My Exception");
        }
    }
}
