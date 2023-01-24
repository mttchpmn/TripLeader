namespace Trips.Model;

public class TripPreview
{
    public Guid Key { get; set; }
    public string Title { get; set; }
    public Guid LeaderKey { get; set; }

    public DateTime DepartureDate { get; set; }
    public DateTime CompletionDate { get; set; }

    public string Route { get; set; }
    public string Details { get; set; }
    public ActivityType ActivityType { get; set; }
    public AbilityLevel AbilityLevel { get; set; }
    public string[] RequiredEquipment { get; set; }
    public string AdditionalInformation { get; set; }

    public TripPreview(Guid key, string title, Guid leaderKey, DateTime departureDate, DateTime completionDate,
        string route, string details, ActivityType activityType, AbilityLevel abilityLevel, string[] requiredEquipment,
        string additionalInformation)
    {
        Key = key;
        Title = title;
        LeaderKey = leaderKey;
        DepartureDate = departureDate;
        CompletionDate = completionDate;
        Route = route;
        Details = details;
        ActivityType = activityType;
        AbilityLevel = abilityLevel;
        RequiredEquipment = requiredEquipment;
        AdditionalInformation = additionalInformation;
    }
}