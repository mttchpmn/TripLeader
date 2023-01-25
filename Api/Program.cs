using Api.Schema.Mutations;
using Api.Schema.Queries;
using Members.Domain;
using Members.Domain.Data;
using Members.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Trips.Domain;
using Trips.Domain.Data;
using Trips.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddAuthorization();

// Configure Hot Chocolate
builder.Services
    .AddGraphQLServer()
    .AddAuthorization()
    
    .AddQueryType<Query>()
    .AddTypeExtension<TripQuery>()
    .AddTypeExtension<MemberQuery>()
    
    .AddMutationType<Mutation>()
    .AddTypeExtension<TripMutation>()
    .AddTypeExtension<MemberMutation>()
    .AddMutationConventions(applyToAllMutations: true)
    
    .AddDefaultTransactionScopeHandler();

// Register DI services
builder.Services.AddSingleton<ITripGateway, TripGateway>();
builder.Services.AddSingleton<ITripService, TripService>();

builder.Services.AddSingleton<IMemberService, MemberService>();
builder.Services.AddSingleton<IMemberGateway, MemberGateway>();

builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(x =>
{
    x.Authority = "https://tripleader.au.auth0.com";
    x.Audience = "https://api.tripleader.io";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.MapGraphQL();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.Run();