using System.Security.Claims;
using Members.Model;
using Trips.Model;

namespace Api.Schema.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class TripMutation
{
    [GraphQLDescription("Creates a new instance of a trip for the authenticated member")]
    public async Task<Trip> CreateTrip([Service] ITripService tripService, TripInput input)
    {
        return await tripService.CreateTrip(input);
    }
    
    [GraphQLDescription("Adds a member to a trip")]
    [Error(typeof(TripException))]
    public async Task<Trip> ApproveTripJoinRequest([Service] ITripService tripService, [Service] IMemberService memberService, ClaimsPrincipal claimsPrincipal, Guid memberKey, Guid tripKey)
    {
        var authId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var member = await memberService.GetMember(authId);
        var isTripAdmin = await tripService.IsTripAdmin(member);

        if (!isTripAdmin)
        {
            throw new TripException("Not authorized to update trip");
        }
        
        return await tripService.ApproveTripJoinRequest(member.Key, memberKey, tripKey);
    }
    
    [GraphQLDescription("Requests to join a trip")]
    [Error(typeof(TripException))]
    public async Task<Trip> CreateTripJoinRequest([Service] ITripService tripService, [Service] IMemberService memberService, ClaimsPrincipal claimsPrincipal, Guid tripKey)
    {
        var authId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var member = await memberService.GetMember(authId);

        
        return await tripService.CreateTripJoinRequest(member.Key, tripKey);
    }
}

public class TripException : Exception
{
    public TripException(string msg) : base(msg)
    {
    }
}