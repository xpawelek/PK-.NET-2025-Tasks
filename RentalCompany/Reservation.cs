namespace RentalCompany;

public class Reservation
{
    public int ReservationId { get; private set; }
    
    private static int nextId = 1;
    public int ReservedVehicleId { get; private set; }
    private string Customer  { get; set; }
    public DateTime ReservationDate { get; private set; }

    public Reservation(int reservedVehicleId, string customer, DateTime reservationDate)
    {
        ReservationId = nextId++;
        ReservedVehicleId = reservedVehicleId;
        Customer = customer;
        ReservationDate = reservationDate;
    }
}