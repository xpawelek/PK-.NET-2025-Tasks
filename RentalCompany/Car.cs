namespace RentalCompany;

public class Car : Vehicle, IReserveable
{
    private string BodyType;

    public Car(string brand, string model, int year, string bodyType)  : base(brand, model, year)
    {
        this.BodyType = BodyType;
    }
    public override void DisplayInfo()
    {
        Console.WriteLine($"Id: {Id}, Brand: {Brand}, Model: {Model}, Year: {Year}, Body Type: {BodyType}");
    }

    public void Reserve(string customer)
    {
        if (!IsAvailable())
        {
            Console.WriteLine("This car is already reserved");
            return;
        }
        
        Console.WriteLine($"Car has been reserved by {customer}");
    }

    public void CancelReservation()
    {
        if (IsAvailable())
        {
            Console.WriteLine("Car has not been reserved yet");
            return;
        }
           
        ChangeAvailable();
        Console.WriteLine($"Car has been returned to rental company");
    }

    public bool IsAvailable()
    {
        return base.IsAvailable;
    }
}