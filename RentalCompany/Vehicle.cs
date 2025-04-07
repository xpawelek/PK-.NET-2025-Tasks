namespace RentalCompany;

public abstract class Vehicle
{
    public int Id { get; private set; }
    private static int nextId = 1;
    public string Brand { get; private set; }
    public string Model { get; private set; }
    public int Year { get; private set; } 
    public bool IsAvailable { get; private set; }

    public Vehicle(string brand, string model, int year)
    {
        Id = nextId++;
        Brand = brand;
        Model = model;
        Year = year;
        IsAvailable = true;
    }
    

    public abstract void DisplayInfo();

    public void ChangeAvailable()
    {
        this.IsAvailable = !this.IsAvailable;
    }
}