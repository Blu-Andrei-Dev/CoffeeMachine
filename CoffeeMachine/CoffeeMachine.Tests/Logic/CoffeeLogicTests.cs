using CoffeeMachine.Api.Logic;
using CoffeeMachine;  // Adjust namespace based on your project
using System;
using Xunit;

public class CoffeeLogicTests
{
    [Fact]
    public void BrewCoffee_NormalCall_Returns200AndCorrectMessage()
    {
        var dateProvider = new FakeDateTimeProvider
        {
            Now = new DateTimeOffset(2026, 2, 3, 10, 0, 0, TimeSpan.Zero)
        };

        var callCounter = new FakeCallCounter();
        var logic = new CoffeeLogic(callCounter, dateProvider);

        var result = logic.BrewCoffee();

        Assert.Equal(200, result.StatusCode);
        Assert.NotNull(result.Response);
        Assert.Equal("Your piping hot coffee is ready", result.Response!.Message);
    }

    [Fact]
    public void BrewCoffee_FifthCall_Returns503WithNoResponse()
    {
        var dateProvider = new FakeDateTimeProvider
        {
            Now = new DateTimeOffset(2026, 2, 3, 10, 0, 0, TimeSpan.Zero)
        };

        var callCounter = new FakeCallCounter(startAt: 4);
        var logic = new CoffeeLogic(callCounter, dateProvider);

        var result = logic.BrewCoffee();

        Assert.Equal(503, result.StatusCode);
        Assert.Null(result.Response);
    }

    [Fact]
    public void BrewCoffee_AprilFirst_Returns418WithNoResponse()
    {
        var dateProvider = new FakeDateTimeProvider
        {
            Now = new DateTimeOffset(2026, 4, 1, 10, 0, 0, TimeSpan.Zero)
        };

        var callCounter = new FakeCallCounter(startAt: 4);
        var logic = new CoffeeLogic(callCounter, dateProvider);

        var result = logic.BrewCoffee();

        Assert.Equal(418, result.StatusCode);
        Assert.Null(result.Response);
    }

    [Fact]
    public void BrewCoffee_AprilFirst_OverridesFifthCall()
    {
        var dateProvider = new FakeDateTimeProvider
        {
            Now = new DateTimeOffset(2024, 4, 1, 10, 0, 0, TimeSpan.Zero)
        };

        var callCounter = new FakeCallCounter(startAt: 9);
        var logic = new CoffeeLogic(callCounter, dateProvider);

        var result = logic.BrewCoffee();

        Assert.Equal(418, result.StatusCode);
    }
}
