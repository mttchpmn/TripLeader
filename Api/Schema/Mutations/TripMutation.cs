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
}