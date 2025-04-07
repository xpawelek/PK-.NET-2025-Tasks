namespace RentalCompany;

public static class RentalCompanyExtensions
{
    public static List<Vehicle> GetAvailableVehicles(this List<Vehicle> vehicles, List<Reservation> reservations,
        DateTime date)
    {
        return vehicles
            .Where(v => !reservations.Any(r =>
                r.ReservedVehicleId == v.Id &&
                r.ReservationDate.Date == date.Date))
            .ToList();
    }
}