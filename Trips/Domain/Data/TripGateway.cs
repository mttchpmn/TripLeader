using Trips.Model;

namespace Trips.Domain.Data;

public class TripGateway : ITripGateway
{
    private readonly Dictionary<Guid, Trip> _trips = new Dictionary<Guid, Trip>();

    public async Task<Trip?> GetTrip(Guid tripKey)
    {
        var tripExists = _trips.TryGetValue(tripKey, out var trip);

        return tripExists
            ? trip
            : null;
    }

    public Task<Trip> CreateTrip(TripInput input)
    {
        throw new NotImplementedException();
    }
}

public class TripNotFoundException : Exception
{
    public TripNotFoundException(string msg) : base(msg)
    {
    }
}