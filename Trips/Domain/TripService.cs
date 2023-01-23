using Trips.Domain.Data;
using Trips.Model;

namespace Trips.Domain;

public class TripService : ITripService
{
    private readonly ITripGateway _tripGateway;

    public TripService(ITripGateway tripGateway)
    {
        _tripGateway = tripGateway;
    }

    public Task<Trip?> GetTrip(Guid tripKey)
    {
        return _tripGateway.GetTrip(tripKey);
    }

    public Task<Trip> CreateTrip(TripInput input)
    {
        throw new NotImplementedException();
    }
}