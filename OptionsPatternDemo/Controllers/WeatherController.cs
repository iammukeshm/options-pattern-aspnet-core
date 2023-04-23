using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace OptionsPatternDemo.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly WeatherOptions _options;
        private readonly WeatherOptions _optionsSnapshot;
        private readonly WeatherOptions _optionsMonitor;
        public WeatherController(IConfiguration configuration, IOptions<WeatherOptions> options, IOptionsSnapshot<WeatherOptions> optionsSnapshot, IOptionsMonitor<WeatherOptions> optionsMonitor)
        {
            _configuration = configuration;
            _options = options.Value;
            _optionsSnapshot = optionsSnapshot.Value;
            _optionsMonitor = optionsMonitor.CurrentValue;
        }

        [HttpGet("config")]
        public IActionResult Get()
        {
            var city = _configuration.GetValue<string>("WeatherOptions:City");
            var state = _configuration.GetValue<string>("WeatherOptions:State");
            var temperature = _configuration.GetValue<int>("WeatherOptions:Temperature");
            var summary = _configuration.GetValue<string>("WeatherOptions:Summary");
            return Ok(new
            {
                City = city,
                State = state,
                Temperature = temperature,
                Summary = summary
            });
        }

        [HttpGet("options")]
        public IActionResult GetFromOptionsPattern()
        {
            var response = new
            {
                options = new { _options.City, _options.State, _options.Temperature, _options.Summary },
                optionsSnapshot = new { _optionsSnapshot.City, _optionsSnapshot.State, _optionsSnapshot.Temperature, _optionsSnapshot.Summary },
                optionsMonitor = new { _optionsMonitor.City, _optionsMonitor.State, _optionsMonitor.Temperature, _optionsMonitor.Summary }
            };

            return Ok(response);
        }
    }
}