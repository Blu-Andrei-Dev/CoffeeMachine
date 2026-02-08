using CoffeeMachine.Api.Logic;
using CoffeeMachine;  // Adjust namespace based on your project
using System;

public class FakeDateTimeProvider : IDateTimeProvider
{
    public DateTimeOffset Now { get; set; }
}
