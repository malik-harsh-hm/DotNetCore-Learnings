using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;

namespace InMemoryCacheExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IMemoryCache _memoryCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IMemoryCache memoryCache)
        {
            _logger = logger;
            _memoryCache = memoryCache;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IActionResult Get()
        {
            var cacheData = _memoryCache.Get<string>("my-key");
            if (cacheData != null)
            {
                return Ok(cacheData);
            }
            var expirationTime = DateTimeOffset.Now.AddSeconds(10.0);
            cacheData = "Hello from Weatherforecase at - " + DateTime.Now.ToString();
            _memoryCache.Set("my-key", cacheData, expirationTime);
            return Ok(cacheData);
        }
    }
}
