namespace Members.Model;

public static class MemberExtensions
{
    public static MemberPreview ToPreview(this Member member)
        => new (
            member.Key,
            member.FirstName,
            member.LastName,
            member.ProfileImageUrl,
            member.Bio,
            member.Activities
        );
}