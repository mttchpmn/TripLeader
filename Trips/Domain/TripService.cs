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
        var trips = await _tripGateway.GetTrips();

        var previews = trips.Select(x => x.ToPreview()).ToList();

        return previews;
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