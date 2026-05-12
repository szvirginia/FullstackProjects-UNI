using Microsoft.AspNetCore.Mvc;
using WeatherForecast_API.Data;
using WeatherForecast_API.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WeatherForecast_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeatherForecastController : ControllerBase
    {
        readonly IWeatherForecastRepository _repo;

        public WeatherForecastController(IWeatherForecastRepository repo)
        {
            _repo = repo;
        }

        // GET: api/<WeatherForecastController>
        [HttpGet]
        public IEnumerable<Forecast> Get()
        {
            return this._repo.Read();
        }

        // GET api/<WeatherForecastController>/5
        [HttpGet("{id}")]
        public Forecast? Get(int id)
        {
            return this._repo.ReadByID(id);
        }

        // POST api/<WeatherForecastController>
        [HttpPost]
        public void Post([FromBody] Forecast forecast)
        {
            this._repo.Create(forecast);
        }

        // PUT api/<WeatherForecastController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Forecast forecast)
        {
            this._repo.Update(forecast);
        }

        // DELETE api/<WeatherForecastController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this._repo.Delete(id);
        }

        [HttpGet("max-degree")]
        public int MaxDegree()
        {
            return this._repo.MaxDegree();
        }
    }
}
