using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using MongoDB.Driver;
using PessoaRead.Api.Extensions;
using PessoaRead.Application.Extensions.DependencyInjection;
using PessoaRead.Extensions;
using PessoaRead.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();
builder.Services.AddHealthChecks()
                .AddMongoDb(dbFactory: sp => sp.GetRequiredService<IMongoDatabase>(), name: "MongoDB", failureStatus: HealthStatus.Unhealthy)
                .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();


app.UseHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapApiEndpoints();


app.Run();
