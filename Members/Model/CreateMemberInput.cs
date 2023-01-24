namespace Members.Model;

public class CreateMemberInput
{
    public string AuthId { get; set; }
    
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmailAddress { get; set; }
}