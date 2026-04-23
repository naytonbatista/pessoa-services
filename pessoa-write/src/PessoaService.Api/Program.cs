using pessoa_service.Extensions;
using pessoa_service.Middlewares;
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
app.UseMiddleware<ExceptionHandlingMiddleware>();
app.Run();
