using Trips.Model;

namespace Members.Model;

public class Member
{
    public int Id { get; set; }
    public string AuthId { get; set; }
    public Guid Key { get; set; }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
    public DateTime DateOfBirth { get; set; }
    public string ProfileImageUrl { get; set; }

    public string Bio { get; set; }
    public IEnumerable<Activity> Activities { get; set; }

    public Member(int id, string authId, Guid key, string firstName, string lastName, string emailAddress,
        DateTime dateOfBirth, string profileImageUrl, string bio, IEnumerable<Activity> activities)
    {
        Id = id;
        AuthId = authId;
        Key = key;
        FirstName = firstName;
        LastName = lastName;
        EmailAddress = emailAddress;
        DateOfBirth = dateOfBirth;
        ProfileImageUrl = profileImageUrl;
        Bio = bio;
        Activities = activities;
    }
}