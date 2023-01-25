
using HotChocolate.AspNetCore.Authorization;

namespace Api.Schema.Queries;

[Authorize]
public class Query
{
    // Empty base query class - specific domain queries are in their own classes
}