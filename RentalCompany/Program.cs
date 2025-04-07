namespace RentalCompany;

class Program
{
    static void Main(string[] args)
    {
        RentalCompany rentalCompany = new RentalCompany();
        rentalCompany.AddVehicle(new Car("Toyota", "Corolla", 2020, "Sedan"));
        rentalCompany.AddVehicle(new Motorcycle("Yamaha", "MT-07", 2021, 689));
        
        rentalCompany.GetAllVehiclesInfo();
        rentalCompany.OnNewReservation += message => Console.WriteLine(message);
        rentalCompany.ReserveVehicle(1, "John Doe", DateTime.Parse("31-03-2025")); 
        rentalCompany.ListAvailableVehiclesForSpecificDate(DateTime.Parse("31-03-2025"));
    }
}
