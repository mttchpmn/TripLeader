using Members.Domain.Data;
using Members.Model;

namespace Members.Domain;

public class MemberService : IMemberService
{
    private readonly IMemberGateway _memberGateway;

    public MemberService(IMemberGateway memberGateway)
    {
        _memberGateway = memberGateway;
    }
    
    public Task<Member> CreateMember(CreateMemberInput input)
    {
        return _memberGateway.CreateMember(input);
    }

    public Task<Member> GetMember(Guid memberKey)
    {
        return _memberGateway.GetMember(memberKey);
    }

    public Task<Member> GetMember(string authId)
    {
        return _memberGateway.GetMember(authId);
    }

    public Task<Member> UpdateMember(UpdateMemberInput input)
    {
        return _memberGateway.UpdateMember(input);
    }

    public Task<Guid> GetMemberKey(string authId)
    {
        return _memberGateway.GetMemberKey(authId);
    }
}