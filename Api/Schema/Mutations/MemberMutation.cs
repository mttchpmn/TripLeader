using Members.Model;

namespace Api.Schema.Mutations;

[ExtendObjectType(typeof(Mutation))]
public class MemberMutation
{
    [GraphQLDescription("Updates member details")]
    public async Task<Member> UpdateMember([Service] IMemberService memberService, UpdateMemberInput input)
    {
        return await memberService.UpdateMember(input);
    }
}