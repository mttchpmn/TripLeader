using Members.Model;

namespace Api.Schema.Queries;

[ExtendObjectType(typeof(Query))]
public class MemberQuery
{
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