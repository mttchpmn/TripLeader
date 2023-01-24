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
}