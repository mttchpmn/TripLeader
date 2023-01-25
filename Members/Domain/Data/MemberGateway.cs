using Members.Model;
using Trips.Model;

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

    public async Task<Member> GetMember(string authId)
    {
        var member = new Member(0, authId, Guid.NewGuid(), "Rick", "Sanchez", "rick@rick.com", DateTime.UnixEpoch, "",
            "", new List<Activity>());

        return member;
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