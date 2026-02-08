namespace CoffeeMachine.Api.Logic
{
    public interface ICallCounter
    {
        int IncrementAndGet();
    }

    public class InMemoryCallCounter : ICallCounter
    {
        private int _count = 0;

        public int IncrementAndGet()
        {
            return Interlocked.Increment(ref _count);
        }
    }
}
