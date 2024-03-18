using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace ResponseCachingExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        [ResponseCache(Location = ResponseCacheLocation.Any, Duration = 10)]
        public IActionResult Get()
        {
            var data = "Hello from Weatherforecast at - " + DateTime.Now.ToString();
            return Ok(data);
        }
    }
}
