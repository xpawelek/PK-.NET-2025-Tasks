namespace StrategyDesignPattern;

public interface IRouteStrategy
{
    void BuildRoute(Coordinates from, Coordinates to);
}