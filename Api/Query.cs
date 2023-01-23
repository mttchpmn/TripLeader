using Trips.Domain.Data;
using Trips.Model;

namespace Api;

public class Query
{
    public async Task<Trip?> GetTrip([Service] ITripService tripService, Guid tripKey)
    {
        return await tripService.GetTrip(tripKey);
    }
}