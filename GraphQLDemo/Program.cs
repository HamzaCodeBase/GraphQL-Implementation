using GraphQLDemo;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Connection")));

builder.AddGraphQL()
    .AddQueryType<Query>()
    .AddMutationType<Mutation>()
    .AddFiltering()
    .AddSorting();


var app = builder.Build();

app.MapGet("/", (context) =>
{
    context.Response.Redirect("/graphql");
    return Task.CompletedTask;
});
app.MapGraphQL();

app.Run();
