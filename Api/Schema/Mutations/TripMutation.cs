using System.Security.Claims;
using Members.Model;
using Trips.Model;

namespace Api.Schema.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class TripMutation
{
    [GraphQLDescription("Create a new trip")]
    public async Task<Trip> CreateTrip([Service] ITripService tripService, TripInput input)
    {
        return await tripService.CreateTrip(input);
    }

    [GraphQLDescription("Create request to join trip")]
    [Error(typeof(TripException))]
    public async Task<OperationResult> CreateTripJoinRequest([Service] ITripService tripService,
        [Service] IMemberService memberService, ClaimsPrincipal claimsPrincipal, Guid tripKey)
    {
        var authId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var member = await memberService.GetMember(authId);


        await tripService.CreateTripJoinRequest(member.Key, tripKey);

        return new OperationResult(true, "Created Trip Join Request successfully");
    }

    [GraphQLDescription("Approve a member's request to join Trip")]
    [Error(typeof(TripException))]
    public async Task<OperationResult> ApproveTripJoinRequest([Service] ITripService tripService,
        [Service] IMemberService memberService, ClaimsPrincipal claimsPrincipal, Guid memberKey, Guid tripKey)
    {
        var authId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var member = await memberService.GetMember(authId);
        var isTripAdmin = await tripService.IsTripAdmin(member);

        if (!isTripAdmin)
        {
            throw new TripException("Not authorized to update trip");
        }

        await tripService.ApproveTripJoinRequest(member.Key, memberKey, tripKey);

        return new OperationResult(true, "Approved request successfully");
    }

    [GraphQLDescription("Generate PDF of the trip manifest for download")]
    public async Task<TripManifest> GenerateTripManifest([Service] ITripService tripService, TripInput input)
    {
        throw new NotImplementedException(); // TODO
    }

    [GraphQLDescription("Update the status of a Trip")]
    public async Task<OperationResult> UpdateTripStatus([Service] ITripService tripService, TripInput input)
    {
        throw new NotImplementedException(); // TODO
    }
}

public record OperationResult(bool WasSuccessful, string Message);

public class TripException : Exception
{
    public TripException(string msg) : base(msg)
    {
    }
}