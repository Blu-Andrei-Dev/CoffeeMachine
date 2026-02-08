using CoffeeMachine.Models;

public class BrewResult
{
    public int StatusCode { get; init; }
    public BrewCoffeeResponse? Response { get; init; }
}