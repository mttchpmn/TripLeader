using System.Security.Claims;
using HotChocolate.AspNetCore.Authorization;
using Trips.Model;

namespace Api.Schema.Queries;

[ExtendObjectType(typeof(Query))]
public class TripQuery
{
    [GraphQLDescription("Gets an existing trip for a trip key")]
    public async Task<Trip?> GetTrip(ClaimsPrincipal claimsPrincipal, [Service] ITripService tripService, Guid tripKey)
    {
        var userId = claimsPrincipal.FindFirstValue(ClaimTypes.NameIdentifier);
        Console.WriteLine($"USER ID: {userId}");
        
        return await tripService.GetTrip(tripKey);
    }
}