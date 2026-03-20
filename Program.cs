using pessoa_service.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiExtensions(builder.Configuration);
builder.Services.AddEndpoints();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapApiEndpoints();

app.Run();
