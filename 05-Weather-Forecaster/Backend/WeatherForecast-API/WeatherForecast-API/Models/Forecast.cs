namespace WeatherForecast_API.Models
{
    public enum WeatherType
    {
        Sunny, Dry, Rainy, Snowy
    }
    public class Forecast
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int Degree { get; set; }
        public int Wind { get; set; }
        public WeatherType? WeatherType { get; set; }
    }
}
