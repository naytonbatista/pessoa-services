using PessoaRead.Api.Extensions;
using PessoaRead.Application.Extensions.DependencyInjection;
using PessoaRead.Extensions;
using PessoaRead.Infrastructure.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpoints();
builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

var app = builder.Build();



Console.WriteLine("Iniciando o serviço de leitura de pessoas...");



app.MapGet("/", () => "Hello Read Service!");
app.MapApiEndpoints();


app.Run();
