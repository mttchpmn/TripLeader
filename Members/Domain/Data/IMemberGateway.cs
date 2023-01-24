using Members.Model;

namespace Members.Domain.Data;

public interface IMemberGateway
{
    Task<Member> CreateMember(CreateMemberInput input);
    Task<Member> GetMember(Guid memberKey);
    Task<Member> UpdateMember(UpdateMemberInput input);
    Task<Guid> GetMemberKey(string authId);
}