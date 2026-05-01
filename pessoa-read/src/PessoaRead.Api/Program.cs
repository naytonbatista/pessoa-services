using PessoaRead.Infrastructure.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure(builder.Configuration);

var app = builder.Build();
Console.WriteLine("Iniciando o serviço de leitura de pessoas...");

app.Run();
