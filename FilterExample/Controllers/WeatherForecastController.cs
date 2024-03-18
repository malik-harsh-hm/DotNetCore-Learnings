using FilterExample.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilterExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [MyResourceFilter]
    [MyActionFilter]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public string Get()
        {
            return "Hello from GetWeatherForecast";
        }
    }
}
