namespace Members.Model;

public interface IMemberService
{
    Task<Member> CreateMember(CreateMemberInput input);
    Task<Member> GetMember(Guid memberKey);
    Task<Member> GetMember(string authId);
    Task<Member> UpdateMember(UpdateMemberInput input);
    Task<Guid> GetMemberKey(string authId);
}