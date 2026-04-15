using pessoa_service.Extensions;
using PessoaService.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddEndpoints();
builder.Services.AddSwaggerConfigs();
builder.Services.AddApplication();

var app = builder.Build();

app.UseSwaggerConfigs();

app.MapGet("/", () => "Hello World!");

app.MapApiEndpoints();

app.Run();
