namespace RentalCompany;

public class Motorcycle : Vehicle, IReserveable
{
    private int EngineCapacity;

    public Motorcycle(string brand, string model, int year, int engineCapacity)  : base(brand, model, year)
    {
        this.EngineCapacity = engineCapacity;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Engine: {EngineCapacity}");
    }
    public void Reserve(string customer)
    {
        if (!IsAvailable())
        {
            Console.WriteLine("This motorcycle is already reserved");
            return;
        }
        
        Console.WriteLine($"Motorcycle has been reserved by {customer}");
    }

    public void CancelReservation()
    {
        if (IsAvailable())
        {
            Console.WriteLine("Motorcycle has not been reserved yet");
            return;
        }
           
        ChangeAvailable();
        Console.WriteLine($"Motorcycle has been returned to rental company");
    }

    public bool IsAvailable()
    {
        return base.IsAvailable;
    }
}