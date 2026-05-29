

using Microsoft.Extensions.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddHealthChecks()
    .AddUrlGroup(new Uri("http://localhost:5273/health"), name: "pessoa-read-api", failureStatus: HealthStatus.Unhealthy)
    .AddUrlGroup(new Uri("http://localhost:5227/health"), name: "pessoa-write-api", failureStatus: HealthStatus.Unhealthy);

builder.Services.AddHealthChecksUI().AddInMemoryStorage();

var app = builder.Build();


app.MapHealthChecks("/health");
app.MapHealthChecksUI(options =>
{
    options.UIPath = "/health-ui";
    options.ApiPath = "/health-ui-api";
});
app.MapReverseProxy();
app.Run();
