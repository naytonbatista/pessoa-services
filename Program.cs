using pessoa_service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiExtensions(builder.Configuration);
builder.Services.AddEndpoints();
builder.Services.AddSwaggerConfigs();

var app = builder.Build();

app.UseSwaggerConfigs();

app.MapGet("/", () => "Hello World!");

app.MapApiEndpoints();

app.Run();
