using Microsoft.AspNetCore.Mvc;

namespace Cache_WebAPI1.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        public IActionResult GetTime()
        {
            return Ok(DateTime.Now.ToString());
        }

        [HttpGet]
        public ActionResult<string> Hello(string name)
        {
            return $"Hello {name} {DateTime.UtcNow} {DateTime.UtcNow.ToLocalTime()}";
        }

        [HttpGet]
        public ActionResult<string> ConvertUtcByTimeZone(int timeZone)
        {
            DateTime timeUtc = DateTime.UtcNow;
            try
            {

                return timeUtc.AddHours(timeZone).ToString();
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Central Standard Time zone.");
            }

            return timeUtc.ToString();
        }

        [HttpGet]
        public ActionResult<string> ConvertUtc(int timeZone)
        {
            DateTime timeUtc = DateTime.UtcNow;
            try
            {

                TimeZoneInfo cstZone = TimeZoneInfo.FindSystemTimeZoneById("Central Standard Time");

                //DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                DateTime cstTime = TimeZoneInfo.ConvertTimeFromUtc(timeUtc, cstZone);
                Console.WriteLine("The date and time are {0} {1}.",
                                  cstTime,
                                  cstZone.IsDaylightSavingTime(cstTime) ?
                                          cstZone.DaylightName : cstZone.StandardName);
            }
            catch (TimeZoneNotFoundException)
            {
                Console.WriteLine("The registry does not define the Central Standard Time zone.");
            }
            catch (InvalidTimeZoneException)
            {
                Console.WriteLine("Registry data on the Central Standard Time zone has been corrupted.");
            }
            return timeUtc.ToString();
        }
    }
}