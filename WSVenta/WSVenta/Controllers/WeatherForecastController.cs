using Microsoft.AspNetCore.Mvc;

namespace WSVenta.Controllers
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
        public IEnumerable<WeatherForecast> Get()
        {
            // Instanciamos una lista para guardar objetos de tipo WeatherForecast y agregamos algunos objetos.
            List <WeatherForecast> lst = new List<WeatherForecast>();
            lst.Add(new WeatherForecast() { Id = 5, Nombre="Jhoan"});
            lst.Add(new WeatherForecast() { Id = 6, Nombre = "Angela"});
            return lst;
        }
    }
}