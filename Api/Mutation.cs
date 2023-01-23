using Trips.Model;

namespace Api;

public class Mutation
{
    [GraphQLDescription("Creates a new instance of a trip for the authenticated member")]
    public  Task<TripCreatedPayload> CreateTrip(Trip trip)
    {
        throw new NotImplementedException();
    }
}

public class TripCreatedPayload
{
    public int MyNUmber { get; set; }
}