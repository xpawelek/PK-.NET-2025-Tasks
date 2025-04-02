namespace StrategyDesignPattern;

public class PublicTransportationStrategy : IRouteStrategy
{
    public void BuildRoute(Coordinates from, Coordinates to)
    {
        Console.WriteLine($"Building public transportation route from {from.getCoordinates()} to {to.getCoordinates()}");
    }
}