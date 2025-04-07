namespace RentalCompany;

public class RentalCompany
{
    List<Vehicle> vehicles = new List<Vehicle>();
    List<Reservation> reservations = new List<Reservation>();
    public event Action<string> OnNewReservation;
    public void AddVehicle(Vehicle vehicle)
    {
        vehicles.Add(vehicle);
    }

    public void ReserveVehicle(int vehicleId, string customer, DateTime reservationDate)
    {
        Vehicle toReserve = vehicles.Find(v => v.Id == vehicleId);

        bool isReservedThatDay = reservations.Any(r =>
                r.ReservedVehicleId == vehicleId &&
                r.ReservationDate.Date == reservationDate.Date 
        );

        if (isReservedThatDay)
        {
            Console.WriteLine("This vehicle is already reserved on that date.");
            return;
        }
        
        if (toReserve is IReserveable reserveable)
        {
            reserveable.Reserve(customer);
            Reservation newReservation = new Reservation(toReserve.Id, customer, reservationDate);
            reservations.Add(newReservation);
            OnNewReservation?.Invoke($"Rezerwacja {newReservation.ReservationId}) Zarezerwowano pojazd ID {vehicleId} dla {customer} na {reservationDate:dd-MM-yyyy}");
        }
        else
        {
            Console.WriteLine("This vehicle cannot be reserved.");
        }
    }

    public void CancelReservation(int reservationId)
    {
        Reservation toCancel = reservations.Find(v=> v.ReservationId == reservationId);
        int canneledIdVehicle = toCancel.ReservedVehicleId;
        Vehicle toCancelVehicle = vehicles.Find(v => v.Id == canneledIdVehicle);
        
        if (toCancelVehicle is IReserveable reserveable)
        {
            reserveable.CancelReservation();
            reservations.Remove(toCancel);
        }
        else
        {
            Console.WriteLine("Something went wrong.");
        }
    }

    public void ListAvailableVehiclesForSpecificDate(DateTime searchDate)
    {
        Console.WriteLine($"Available vehicles for specified date {searchDate}:");
        var availableVehicles =  vehicles.GetAvailableVehicles(reservations, searchDate);

        foreach (var vehicle in availableVehicles)
        {
            vehicle.DisplayInfo();
        }
    }

    public void GetAllVehiclesInfo()
    {
        Console.WriteLine("Getting all vehicles...");
        foreach (var vehicle in GetAllVahicles())
        {
            vehicle.DisplayInfo();
        }
    }

    public List<Vehicle> GetAllVahicles()
    {
        return vehicles;
    }
    
}