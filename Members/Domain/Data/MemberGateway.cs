using Members.Model;

namespace Members.Domain.Data;

public class MemberGateway : IMemberGateway
{
    public Task<Member> CreateMember(CreateMemberInput input)
    {
        throw new NotImplementedException();
    }

    public Task<Member> GetMember(Guid memberKey)
    {
        throw new NotImplementedException();
    }

    public Task<Member> UpdateMember(UpdateMemberInput input)
    {
        throw new NotImplementedException();
    }

    public Task<Guid> GetMemberKey(string authId)
    {
        throw new NotImplementedException();
    }
}