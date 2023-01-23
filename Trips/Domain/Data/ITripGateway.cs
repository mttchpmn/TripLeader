using Trips.Model;

namespace Trips.Domain.Data;

public interface ITripGateway
{
    Task<Trip?> GetTrip(Guid tripKey);
    Task<Trip> CreateTrip(TripInput input);
}