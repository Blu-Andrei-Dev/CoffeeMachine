

namespace CoffeeMachine.Services
{
    public interface IWeatherService
    {
        Task<double> GetCurrentTemperatureAsync();
    }

    public class WeatherService : IWeatherService
    {
        private readonly double _temperature;

        public WeatherService(double temperature)
        {
            _temperature = temperature;
        }

        public Task<double> GetCurrentTemperatureAsync()
        {
            return Task.FromResult(_temperature);
        }
    }
}
