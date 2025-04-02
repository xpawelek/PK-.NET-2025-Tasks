namespace StrategyDesignPattern;

public class CarStrategy : IRouteStrategy
{
    public void BuildRoute(Coordinates from, Coordinates to)
    {
        Console.WriteLine($"Building car route from {from.getCoordinates()} to {to.getCoordinates()}");
    }
}