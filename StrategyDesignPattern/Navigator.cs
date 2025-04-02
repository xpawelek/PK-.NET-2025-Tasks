namespace StrategyDesignPattern;

public class Navigator
{
    private IRouteStrategy _route;

    public Navigator(IRouteStrategy route)
    {
        this._route = route;
    }
    
    public void BuildRoute(Coordinates from, Coordinates to)
    {
        this._route.BuildRoute(from, to);
    }

    public void SetStrategy(IRouteStrategy strategy)
    {
        this._route = strategy;
    }
}