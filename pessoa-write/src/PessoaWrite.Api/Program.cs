using PessoaWrite.Extensions;
using PessoaWrite.Middlewares;
using PessoaWrite.Infrastructure.Extensions;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;
using HealthChecks.UI.Client;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpoints();
builder.Services.AddSwaggerConfigs();
builder.Services.AddApplication();
builder.Services.AddHealthChecks()
                .AddNpgSql(builder.Configuration.GetConnectionString("DefaultConnection")!, name: "PostgreSQL", failureStatus: HealthStatus.Unhealthy)
                .AddCheck("self", () => HealthCheckResult.Healthy());

var app = builder.Build();

app.UseSwaggerConfigs();

app.MapHealthChecks("/health", new HealthCheckOptions
{
    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.MapApiEndpoints();
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
