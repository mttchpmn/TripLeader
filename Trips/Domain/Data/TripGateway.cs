using Trips.Model;

namespace Trips.Domain.Data;

public class TripGateway : ITripGateway
{
    private readonly Dictionary<Guid, Trip> _trips = new()
    {
        {
            Guid.NewGuid(), new Trip(
                1,
                Guid.NewGuid(),
                "St Heliers to Rangitoto Kayaking",
                Guid.NewGuid(),
                DateTime.Today.AddDays(3),
                DateTime.Today.AddDays(3),
                DateTime.Today.AddDays(3),
                "St Heliers to Coastguard Bay",
                "Should be a good trip",
                ActivityType.SeaKayaking,
                AbilityLevel.Intermediate,
                new string[] {"Sea kayak"},
                ""
            )
        },
        {
            new Guid(), new Trip(
                2,
                Guid.NewGuid(),
                "Woodhill Mountain Biking",
                Guid.NewGuid(),
                DateTime.Today.AddDays(4),
                DateTime.Today.AddDays(4),
                DateTime.Today.AddDays(4),
                "Mostly black trails",
                "Should be a good trip",
                ActivityType.MountainBiking,
                AbilityLevel.Advanced,
                new string[] {"Mountain Bike"},
                ""
            )
        },
        {
            Guid.NewGuid(),
            new(
                3,
                Guid.NewGuid(),
                "Tongariro Crossing",
                Guid.NewGuid(),
                DateTime.Today.AddDays(9),
                DateTime.Today.AddDays(10),
                DateTime.Today.AddDays(10),
                "Tongariro circuit",
                "Should be a good trip",
                ActivityType.Hiking,
                AbilityLevel.Beginner,
                Array.Empty<string>(),
                ""
            )
        }
    };

    public async Task<Trip?> GetTrip(Guid tripKey)
    {
        var tripExists = _trips.TryGetValue(tripKey, out var trip);

        return tripExists
            ? trip
            : null;
    }

    public async Task<IEnumerable<Trip>> GetTrips()
    {
        return _trips.Values.ToList();
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
            input.ActivityType,
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