namespace RentalCompany;

public interface IReserveable
{
    void Reserve(string customer);
    void CancelReservation();
    bool IsAvailable();
}