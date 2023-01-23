using Trips.Model;

namespace Trips.Domain.Data;

public class TripGateway : ITripGateway
{
    private readonly Dictionary<Guid, Trip> _trips = new ();

    public async Task<Trip?> GetTrip(Guid tripKey)
    {
        var tripExists = _trips.TryGetValue(tripKey, out var trip);

        return tripExists
            ? trip
            : null;
    }

    public Task<Trip> CreateTrip(TripInput input)
    {
        var tripGuid = Guid.NewGuid();
        var trip = new Trip
        (
            0,
            tripGuid,
            input.Title,
            Guid.NewGuid(),
            input.DepartureDate,
            input.CompletionDate,
            input.SarTime,
            input.Route,
            input.Details,
            input.Activity,
            input.AbilityLevel,
            input.RequiredEquipment,
            input.AdditionalInformation
        );
        
        _trips.Add(tripGuid, trip);

        return Task.FromResult(trip);
    }
}

public class TripNotFoundException : Exception
{
    public TripNotFoundException(string msg) : base(msg)
    {
    }
}