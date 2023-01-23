namespace Trips.Model;

public interface ITripService
{
    Task<Trip?> GetTrip(Guid tripKey);
    Task<Trip> CreateTrip(TripInput input);
}