using Trips.Model;

namespace Api;

public class Mutation
{
    [GraphQLDescription("Creates a new instance of a trip for the authenticated member")]
    public async Task<Trip> CreateTrip([Service] ITripService tripService, TripInput input)
    {
        return await tripService.CreateTrip(input);
    }
}

public class TripCreatedPayload
{
    public int MyNUmber { get; set; }
}