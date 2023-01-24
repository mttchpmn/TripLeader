using Trips.Model;

namespace Members.Model;

public class MemberPreview
{
    public Guid Key { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string ProfileImageUrl { get; set; }

    public string Bio { get; set; }
    public IEnumerable<Activity> Activities { get; set; }
    
    public MemberPreview(Guid key, string firstName, string lastName, string profileImageUrl, string bio, IEnumerable<Activity> activities)
    {
        Key = key;
        FirstName = firstName;
        LastName = lastName;
        ProfileImageUrl = profileImageUrl;
        Bio = bio;
        Activities = activities;
    }

}