using Members.Model;

namespace Trips.Model;

public interface ITripService
{
    Task<Trip?> GetTrip(Guid tripKey);
    Task<Trip> CreateTrip(TripInput input);
    Task<bool> IsTripParticipant(Member member);
    Task<bool> IsTripAdmin(Member member);
    Task<Trip> AddMemberToTrip(Guid AdminKey, Guid memberKey, Guid tripKey);
}