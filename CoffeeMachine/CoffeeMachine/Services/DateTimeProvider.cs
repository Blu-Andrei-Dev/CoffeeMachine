namespace CoffeeMachine.Api.Logic
{
    public interface IDateTimeProvider
    {
        DateTimeOffset Now { get; }
    }

    public class SystemDateTimeProvider : IDateTimeProvider
    {
        public DateTimeOffset Now => DateTimeOffset.UtcNow;
    }
}
