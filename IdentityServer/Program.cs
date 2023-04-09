using IdentityServer;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddIdentityServer()
               .AddInMemoryClients(Config.Clients)
               .AddInMemoryApiScopes(Config.ApiScopes())
               .AddInMemoryApiResources(Config.ApiResources)
               .AddDeveloperSigningCredential();

var app = builder.Build();

app.UseHttpsRedirection();
app.UseIdentityServer();
app.UseAuthorization();

app.MapControllers();

app.Run();
