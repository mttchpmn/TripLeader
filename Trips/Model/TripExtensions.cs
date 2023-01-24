namespace Trips.Model;

public static class TripExtensions
{
    public static TripPreview ToPreview(this Trip trip)
        => new(
            trip.Key,
            trip.Title,
            trip.LeaderKey,
            trip.DepartureDate,
            trip.CompletionDate,
            trip.Route,
            trip.Details,
            trip.ActivityType,
            trip.AbilityLevel,
            trip.RequiredEquipment,
            trip.AdditionalInformation
        );
}