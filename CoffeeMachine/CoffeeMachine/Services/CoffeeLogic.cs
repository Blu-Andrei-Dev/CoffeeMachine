using CoffeeMachine.Models;
using CoffeeMachine.Services;

namespace CoffeeMachine.Api.Logic
{
    public interface ICoffeeLogic
    {
        Task<BrewResult> BrewCoffee();
    }

    public class CoffeeLogic : ICoffeeLogic
    {
        private readonly ICallCounter _callCounter;
        private readonly IDateTimeProvider _dateTimeProvider;
        private readonly IWeatherService _weatherService;

        public CoffeeLogic(
            ICallCounter callCounter,
            IDateTimeProvider dateTimeProvider,
            IWeatherService weatherService)
        {
            _callCounter = callCounter;
            _dateTimeProvider = dateTimeProvider;
            _weatherService = weatherService;
        }

        public async Task<BrewResult> BrewCoffee()
        {
            var now = _dateTimeProvider.Now;

            if (now.Month == 4 && now.Day == 1)
            {
                return new BrewResult
                {
                    StatusCode = StatusCodes.Status418ImATeapot
                };
            }

            var callNumber = _callCounter.IncrementAndGet();
            if (callNumber % 5 == 0)
            {
                return new BrewResult
                {
                    StatusCode = StatusCodes.Status503ServiceUnavailable
                };
            }

            string message = "Your piping hot coffee is ready";

            double temp = await _weatherService.GetCurrentTemperatureAsync();
            if (temp > 30)
            {
                message = "Your refreshing iced coffee is ready";
            }

            return new BrewResult
            {
                StatusCode = StatusCodes.Status200OK,
                Response = new BrewCoffeeResponse
                {
                    Message = message,
                    Prepared = now.ToString("yyyy-MM-ddTHH:mm:sszzz")
                }
            };
        }
    }

}
