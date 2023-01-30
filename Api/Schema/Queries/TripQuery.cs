using System.Security.Claims;
using HotChocolate.AspNetCore.Authorization;
using HotChocolate.Execution;
using Members.Model;
using Trips.Model;

namespace Api.Schema.Queries;

[ExtendObjectType(typeof(Query))]
public class TripQuery
{
    [GraphQLDescription("Gets publicly available trip previews")]
    public async Task<IEnumerable<TripPreview>> GetTripPreviews([Service] ITripService tripService)
    {
        return await tripService.GetTripPreviews();
    }
    
    
    [GraphQLDescription("Gets full detail for a trip")]
    public async Task<Trip?> GetTripDetail(ClaimsPrincipal claimsPrincipal, [Service] ITripService tripService, [Service] IMemberService memberService, Guid tripKey)
    {
        var authId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);

        var member = await memberService.GetMember(authId);
        var isTripParticipant = await tripService.IsTripParticipant(member);

        if (!isTripParticipant)
            throw new QueryException("Not authorized to access trip detail");
        
        return await tripService.GetTrip(tripKey);
    }

    [GraphQLDescription("Gets public preview detail for a trip")]
    public async Task<TripPreview?> GetTripPreview([Service] ITripService tripService, Guid tripKey)
    {
        // NB: No Authorization required as the user is already authenticated, and we're only fetching the public preview
        var trip =  await tripService.GetTrip(tripKey);
        
        return trip?.ToPreview();
    }
}