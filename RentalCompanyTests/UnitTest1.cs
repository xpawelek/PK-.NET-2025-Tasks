namespace RentalCompanyTests;
using RentalCompany;

public class Tests
{
    private RentalCompany company;
    private Car car1;
    private Car car2;
    private Motorcycle motorcycle1;
    private Motorcycle motorcycle2;
    
    [SetUp]
    public void Setup()
    {
        company = new RentalCompany();
        car1 = new Car("Toyota", "Corolla", 2020, "Sedan");
        car2 = new Car("Toyota", "Aygo", 2006, "Hatchback");
        motorcycle1 = new Motorcycle("Yamaha", "MT-07", 2021, 689);
        motorcycle2 = new Motorcycle("Yamaha", "MT-02", 2010, 360);
    }

    [Test]
    public void AddFewVehiclesToCompany_ShouldAddFewVehicles()
    {
        company.AddVehicle(car1);
        company.AddVehicle(car2);

        var allVehicles = company.GetAllVahicles();
        Assert.AreEqual(2, allVehicles.Count);
        Assert.Contains(car1, allVehicles);
        Assert.Contains(car2, allVehicles);
    }

    [Test]
    public void GetAvailableVehicles_ShouldReturnOnlyFreeVehicles()
    {
        var vehicles = new List<Vehicle> { car1, car2 };
        var reservations = new List<Reservation>
        {
            new Reservation(car1.Id, "John Doe", DateTime.Parse("31-03-2025"))
        };
        
        var available = vehicles.GetAvailableVehicles(reservations, DateTime.Parse("31-03-2025"));

        Assert.IsTrue(available.Contains(car2));      
        Assert.IsFalse(available.Contains(car1));     
        Assert.AreEqual(1, available.Count);   
    }
    
    [Test]
    public void ReserveVehicle_ShouldReserveVehicleIfAvailable()
    {
        company.AddVehicle(car1);

        string receivedMessage = null;
        company.OnNewReservation += msg => receivedMessage = msg;

        company.ReserveVehicle(car1.Id, "Alice", new DateTime(2025, 3, 31));

        var available = company.GetAllVahicles().GetAvailableVehicles(
            new List<Reservation> { new Reservation(car1.Id, "Alice", new DateTime(2025, 3, 31)) },
            new DateTime(2025, 3, 31));

        Assert.IsEmpty(available);
        Assert.IsNotNull(receivedMessage);
        StringAssert.Contains("Zarezerwowano pojazd ID", receivedMessage);
    }
    
    [Test]
    public void ListAvailableVehiclesForSpecificDate_ShouldShowCorrectVehicles()
    {
        company.AddVehicle(car1);
        company.AddVehicle(car2);
        company.ReserveVehicle(car1.Id, "Alice", new DateTime(2025, 3, 31));

        var available = company.GetAllVahicles().GetAvailableVehicles(
            new List<Reservation> { new Reservation(car1.Id, "Alice", new DateTime(2025, 3, 31)) },
            new DateTime(2025, 3, 31));

        Assert.Contains(car2, available);
        Assert.IsFalse(available.Contains(car1));
    }
    
    
}