using WeatherForecast_API.Models;

namespace WeatherForecast_API.Data
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        readonly WeatherForecastDbContext _dbcontext;

        public WeatherForecastRepository(WeatherForecastDbContext dbcontext)
        {
            _dbcontext = dbcontext;
        }

        public void Create(Forecast forecast)
        {
            this._dbcontext.Add(forecast);
            _dbcontext.SaveChanges();
        }

        public void Delete(int id)
        {
            Forecast toDelete = this.ReadByID(id);
            if (toDelete != null)
            {
                this._dbcontext.Remove(toDelete);
            }
            _dbcontext.SaveChanges();
        }

        public int MaxDegree()
        {
            return this._dbcontext.Forecasts
                .Max(x  => x.Degree);
        }

        public IEnumerable<Forecast> Read()
        {
            return this._dbcontext.Forecasts;
        }

        public Forecast? ReadByID(int id)
        {
            return _dbcontext.Forecasts.FirstOrDefault(x => x.Id == id);
        }

        public void Update(Forecast forecast)
        {
            this._dbcontext.Update(forecast);
        }
    }
}
