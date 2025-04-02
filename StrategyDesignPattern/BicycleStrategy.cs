namespace StrategyDesignPattern;

public class BicycleStrategy : IRouteStrategy
{
    public void BuildRoute(Coordinates from, Coordinates to)
    {
        Console.WriteLine($"Building bicycle route from {from.getCoordinates()} to {to.getCoordinates()}");
    }
}