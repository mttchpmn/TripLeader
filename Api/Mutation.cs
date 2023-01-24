using Members.Model;
using Trips.Model;

namespace Api;

public class Mutation
{
    [GraphQLDescription("Creates a new instance of a trip for the authenticated member")]
    public async Task<Trip> CreateTrip([Service] ITripService tripService, TripInput input)
    {
        return await tripService.CreateTrip(input);
    }

    [GraphQLDescription("Updates member details")]
    public async Task<Member> UpdateMember([Service] IMemberService memberService, UpdateMemberInput input)
    {
        return await memberService.UpdateMember(input);
    }
}
