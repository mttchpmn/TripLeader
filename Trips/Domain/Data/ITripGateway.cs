using Trips.Model;

namespace Trips.Domain.Data;

public interface ITripGateway
{
    Task<Trip?> GetTrip(Guid tripKey);
    Task<IEnumerable<Trip>> GetTrips();
    Task<Trip> CreateTrip(TripInput input);
}