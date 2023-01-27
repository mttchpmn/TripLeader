using Members.Model;

namespace Trips.Model;

public interface ITripService
{
    Task<Trip?> GetTrip(Guid tripKey);
    Task<Trip> CreateTrip(TripInput input);
    Task<bool> IsTripParticipant(Member member);
    Task<bool> IsTripAdmin(Member member);
    Task<Trip> AddMemberToTrip(Guid AdminKey, Guid memberKey, Guid tripKey);
    Task<Trip> ApproveTripJoinRequest(Guid memberKey, Guid guid, Guid tripKey);
    Task<Trip> CreateTripJoinRequest(Guid memberKey, Guid tripKey);
}