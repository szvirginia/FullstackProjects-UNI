using WeatherForecast_API.Models;

namespace WeatherForecast_API.Data
{
    public interface IWeatherForecastRepository
    {
        IEnumerable<Forecast> Read();
        Forecast ReadByID(int id);
        void Create(Forecast forecast);
        void Update(Forecast forecast);
        void Delete(int id);

        //NON_CRUD
        int MaxDegree();
    }
}
