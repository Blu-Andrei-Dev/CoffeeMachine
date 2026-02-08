using CoffeeMachine.Api.Logic;
using CoffeeMachine.Models;
using Microsoft.AspNetCore.Mvc;

namespace CoffeeMachine.Controllers
{
    [ApiController]
    [Route("")]
    public class CoffeeController : ControllerBase
    {
        private readonly ICoffeeLogic _coffeeLogic;

        public CoffeeController(ICoffeeLogic coffeeLogic)
        {
            _coffeeLogic = coffeeLogic;
        }

        [HttpGet("brew-coffee")]
        public async Task BrewCoffee()
        {
            var result = _coffeeLogic.BrewCoffee();

            if (result.Response is null)
            {
                Response.Clear();
                Response.StatusCode = result.StatusCode;
                return;
            }

            Response.StatusCode = result.StatusCode;
            await Response.WriteAsJsonAsync(result.Response);
        }
    }

}
