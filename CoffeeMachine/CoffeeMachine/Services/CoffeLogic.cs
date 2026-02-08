using CoffeeMachine.Models;

namespace CoffeeMachine.Api.Logic
{
    public interface ICoffeeLogic
    {
        BrewResult BrewCoffee();
    }

    public class CoffeeLogic : ICoffeeLogic
    {
        private readonly ICallCounter _callCounter;
        private readonly IDateTimeProvider _dateTimeProvider;

        public CoffeeLogic(
            ICallCounter callCounter,
            IDateTimeProvider dateTimeProvider)
        {
            _callCounter = callCounter;
            _dateTimeProvider = dateTimeProvider;
        }

        public BrewResult BrewCoffee()
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


            return new BrewResult
            {
                StatusCode = StatusCodes.Status200OK,
                Response = new BrewCoffeeResponse
                {
                    Message = "Your piping hot coffee is ready",
                    Prepared = now.ToString("yyyy-MM-ddTHH:mm:sszzz")
                }
            };
        }
    }
}
