using pessoa_service.Extensions;
using pessoa_service.Features.Pessoas;
using pessoa_service.Features.Contatos;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfigurations(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapApiEndpoints();

app.Run();
