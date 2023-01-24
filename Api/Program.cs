using Api;
using Api.Schema.Mutations;
using Api.Schema.Queries;
using Members.Domain;
using Members.Domain.Data;
using Members.Model;
using Trips.Domain;
using Trips.Domain.Data;
using Trips.Model;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();

// Configure Hot Chocolate
builder.Services.AddGraphQLServer()
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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    // app.UseSwagger();
    // app.UseSwaggerUI();
}

app.MapGraphQL();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();