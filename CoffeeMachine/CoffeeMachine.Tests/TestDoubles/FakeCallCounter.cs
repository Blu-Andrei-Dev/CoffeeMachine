using CoffeeMachine.Api.Logic;
using CoffeeMachine;

public class FakeCallCounter : ICallCounter
{
    private int _count;

    public FakeCallCounter(int startAt = 0)
    {
        _count = startAt;
    }

    public int IncrementAndGet()
    {
        _count++;
        return _count;
    }
}

