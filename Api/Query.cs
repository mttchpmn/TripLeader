using Members.Model;
using Trips.Domain.Data;
using Trips.Model;

namespace Api;

public class Query
{
    [GraphQLDescription("Gets an existing trip for a trip key")]
    public async Task<Trip?> GetTrip([Service] ITripService tripService, Guid tripKey)
    {
        return await tripService.GetTrip(tripKey);
    }

    [GraphQLDescription("Gets details of a member")]
    public async Task<MemberPreview> GetMember([Service] IMemberService memberService, Guid memberKey)
    {
        var member = await memberService.GetMember(memberKey);

        return member.ToPreview();
    }
    
    [GraphQLDescription("Gets details of the currently logged in member")]
    public async Task<Member> GetCurrentMember([Service] IMemberService memberService, string authId)
    {
        var memberKey = await memberService.GetMemberKey(authId);
        var member = await memberService.GetMember(memberKey);

        return member;
    }
}