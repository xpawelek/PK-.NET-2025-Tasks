namespace StrategyDesignPattern;

class Program
{
    static void Main(string[] args)
    {
        Navigator navigator = new Navigator(new WalkingStrategy());
        Coordinates cord1 = new Coordinates(2, 2);
        Coordinates cord2 = new Coordinates(3, 3);
        navigator.BuildRoute(cord1, cord2);
        
        navigator.SetStrategy(new CarStrategy());
        navigator.BuildRoute(cord1, cord2);
    }
}