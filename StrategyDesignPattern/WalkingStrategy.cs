namespace StrategyDesignPattern;

public class WalkingStrategy : IRouteStrategy
{
    public void BuildRoute(Coordinates from, Coordinates to)
    {
        Console.WriteLine($"Walking from {from.getCoordinates()} to {to.getCoordinates()}");
    }
}