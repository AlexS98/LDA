using Lesson17.Dto;

using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lesson17.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static List<string> Summaries = new List<string>
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> GetForecast()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Count)]
            })
            .ToArray();
        }

        [HttpPost]
        public IEnumerable<WeatherForecast> AddPost([FromBody] WeatherDto dto)
        {
            Summaries.Add(dto.NewWeather);
            return GetForecast();
        }

        [HttpGet("data")]
        public IEnumerable<string> GetData() => Summaries;

        [HttpPost("replace")]
        public IEnumerable<WeatherForecast> ReplacePost([FromBody] WeatherReplaceDto dto)
        {
            if (dto.Append)
            {
                Summaries.AddRange(dto.ReplaceList);
            }
            else
            {
                Summaries = dto.ReplaceList;
            }
            return GetForecast();
        }
    }
}
