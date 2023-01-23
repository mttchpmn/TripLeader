namespace Trips.Model;

public class TripInput
{
    public string Title { get; set; }

    public DateTime DepartureDate { get; set; }
    public DateTime CompletionDate { get; set; }
    public DateTime SarTime { get; set; }

    public string Route { get; set; }
    public string Details { get; set; }
    public Activity Activity { get; set; }
    public AbilityLevel AbilityLevel { get; set; }
    public string[] RequiredEquipment { get; set; }
    public string AdditionalInformation { get; set; }
}