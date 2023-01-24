using Trips.Model;

namespace Api.Schema.Queries;

[ExtendObjectType(typeof(Query))]
public class TripQuery
{
    [GraphQLDescription("Gets an existing trip for a trip key")]
    public async Task<Trip?> GetTrip([Service] ITripService tripService, Guid tripKey)
    {
        return await tripService.GetTrip(tripKey);
    }
}