using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace DistributedCacheExample.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IDistributedCache _distributedCache;

        public WeatherForecastController(ILogger<WeatherForecastController> logger, IDistributedCache distributedCache)
        {
            _logger = logger;
            _distributedCache = distributedCache;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public async Task<IActionResult> Get()
        {
            var cacheData = await _distributedCache.GetStringAsync("my-key");
            if (cacheData != null)
            {
                return Ok(cacheData);
            }
            var expirationTime = DateTimeOffset.Now.AddSeconds(10.0);
            var cacheOptions = new DistributedCacheEntryOptions().SetAbsoluteExpiration(expirationTime);
            cacheData = "Hello from Weatherforecase at - " + DateTime.Now.ToString();
            await _distributedCache.SetStringAsync("my-key", cacheData, cacheOptions);
            return Ok(cacheData);
        }
    }
}
