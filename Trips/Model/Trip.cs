namespace Trips.Model;

public class Trip
{
    public int Id { get; set; }
    public Guid Key { get; set; }
    public string Title { get; set; }
    public TripStatus Status { get; set; }
    public Guid LeaderKey { get; set; }

    public DateTime DepartureDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public DateTime SarTime { get; set; }

    public string Route { get; set; }
    public string Details { get; set; }
    public ActivityType ActivityType { get; set; }
    public AbilityLevel AbilityLevel { get; set; }
    public string[] RequiredEquipment { get; set; }
    public string AdditionalInformation { get; set; }
    
    public Trip(int id, Guid key, string title, Guid leaderKey, DateTime departureDate, DateTime completionDate,
        DateTime sarTime, string route, string details, ActivityType activityType, AbilityLevel abilityLevel,
        string[] requiredEquipment, string additionalInformation)
    {
        Id = id;
        Key = key;
        Title = title;
        LeaderKey = leaderKey;
        DepartureDate = departureDate;
        CompletionDate = completionDate;
        SarTime = sarTime;
        Route = route;
        Details = details;
        ActivityType = activityType;
        AbilityLevel = abilityLevel;
        RequiredEquipment = requiredEquipment;
        AdditionalInformation = additionalInformation;
    }

}