using Members.Model;
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

    public async Task<IEnumerable<TripPreview>> GetTripPreviews()
    {
        var mockData = new List<TripPreview>
        {
            new (
                Guid.NewGuid(),
                "St Heliers to Rangitoto Kayaking",
                Guid.NewGuid(),
                DateTime.Today.AddDays(3),
                DateTime.Today.AddDays(3),
                "St Heliers to Coastguard Bay",
                "Should be a good trip",
                ActivityType.SeaKayaking,
                AbilityLevel.Intermediate,
                new string[] {"Sea kayak"},
                ""
            ),
            new (
                Guid.NewGuid(),
                "Woodhill Mountain Biking",
                Guid.NewGuid(),
                DateTime.Today.AddDays(4),
                DateTime.Today.AddDays(4),
                "Mostly black trails",
                "Should be a good trip",
                ActivityType.MountainBiking,
                AbilityLevel.Advanced,
                new string[] {"Mountain Bike"},
                ""
            ),
            new (
                Guid.NewGuid(),
                "Tongariro Crossing",
                Guid.NewGuid(),
                DateTime.Today.AddDays(9),
                DateTime.Today.AddDays(10),
                "Tongariro circuit",
                "Should be a good trip",
                ActivityType.Hiking,
                AbilityLevel.Beginner,
                Array.Empty<string>(),
                ""
            )
        };

        return mockData;
    }

    public async Task<Trip> CreateTrip(TripInput input)
    {
        return await _tripGateway.CreateTrip(input);
    }

    public async Task<bool> IsTripParticipant(Member member)
    {
        return false;
    }

    public async Task<bool> IsTripAdmin(Member member)
    {
        return false;
    }

    public Task<Trip> AddMemberToTrip(Guid AdminKey, Guid memberKey, Guid tripKey)
    {
        throw new NotImplementedException();
    }

    public Task<Trip> ApproveTripJoinRequest(Guid memberKey, Guid guid, Guid tripKey)
    {
        throw new NotImplementedException();
    }

    public Task<Trip> CreateTripJoinRequest(Guid memberKey, Guid tripKey)
    {
        throw new NotImplementedException();
    }
}