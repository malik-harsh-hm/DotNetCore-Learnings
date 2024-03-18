using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OptionsPattern.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TestConfigurationController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly MyOptions _myOptions;
        private readonly MyOptions _myOptionsSnapshot;
        private readonly MyOptions _myOptionsMonitor;

        public TestConfigurationController(IConfiguration configuration, IOptions<MyOptions> options,
            IOptionsSnapshot<MyOptions> optionsSnapshot, IOptionsMonitor<MyOptions> optionsMonitor)
        {
            _configuration = configuration;
            _myOptions = options.Value;
            _myOptionsSnapshot = optionsSnapshot.Value;
            _myOptionsMonitor = optionsMonitor.CurrentValue;
        }

        [HttpGet(Name = "config")]
        public IActionResult Get()
        {
            var section = _configuration.GetSection("MyOptions");

            var valueFromIConfiguration = section.GetValue<string>("MyKey");
            var valueFromIOptions = _myOptions.MyKey;
            var valueFromIOptionsSnapshot = _myOptionsSnapshot.MyKey;
            var valueFromIOptionsMonitor = _myOptionsMonitor.MyKey;

            return Ok(new
            {
                valueFromIConfiguration,
                valueFromIOptions,
                valueFromIOptionsSnapshot,
                valueFromIOptionsMonitor
            });
        }
    }
}
