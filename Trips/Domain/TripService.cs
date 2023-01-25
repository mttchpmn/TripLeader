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
}