using Filter_Example.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FilterExample.Controllers
{
    [ApiController]
    [Route("[controller]")]

    [MyResourceFilter] // Resource Filter
    [MyActionFilter] // Action Filter
    [MyExceptionFilter] // Exception Filter
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
            throw new BadRequestException("My Exception");
            return "Hello from GetWeatherForecast";
        }
    }
}
