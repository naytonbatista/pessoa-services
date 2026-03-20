using Microsoft.EntityFrameworkCore;
using pessoa_service.Configurations;
using pessoa_service.Data;
using pessoa_service.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfigurations(builder.Configuration);

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

// CRUD Pessoa
app.MapGet("/pessoas", async (AppDbContext db) =>
    await db.Pessoas.Include(p => p.Contatos).ToListAsync());

app.MapGet("/pessoas/{id:int}", async (int id, AppDbContext db) =>
{
    var pessoa = await db.Pessoas.Include(p => p.Contatos).FirstOrDefaultAsync(p => p.Id == id);
    return pessoa is not null ? Results.Ok(pessoa) : Results.NotFound();
});

app.MapPost("/pessoas", async (Pessoa pessoa, AppDbContext db) =>
{
    pessoa.CreatedAt = DateTime.UtcNow;
    pessoa.UpdatedAt = DateTime.UtcNow;
    db.Pessoas.Add(pessoa);
    await db.SaveChangesAsync();
    return Results.Created($"/pessoas/{pessoa.Id}", pessoa);
});

app.MapPut("/pessoas/{id:int}", async (int id, Pessoa input, AppDbContext db) =>
{
    var pessoa = await db.Pessoas.FindAsync(id);
    if (pessoa is null) return Results.NotFound();

    pessoa.Nome = input.Nome;
    pessoa.Email = input.Email;
    pessoa.Telefone = input.Telefone;
    pessoa.DataNascimento = input.DataNascimento;
    pessoa.Ativo = input.Ativo;
    pessoa.UpdatedAt = DateTime.UtcNow;

    await db.SaveChangesAsync();
    return Results.Ok(pessoa);
});

app.MapDelete("/pessoas/{id:int}", async (int id, AppDbContext db) =>
{
    var pessoa = await db.Pessoas.FindAsync(id);
    if (pessoa is null) return Results.NotFound();

    db.Pessoas.Remove(pessoa);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

// CRUD Contato
app.MapGet("/contatos", async (AppDbContext db) =>
    await db.Contatos.Include(c => c.Pessoa).ToListAsync());

app.MapGet("/contatos/{id:int}", async (int id, AppDbContext db) =>
{
    var contato = await db.Contatos.Include(c => c.Pessoa).FirstOrDefaultAsync(c => c.Id == id);
    return contato is not null ? Results.Ok(contato) : Results.NotFound();
});

app.MapPost("/contatos", async (Contato contato, AppDbContext db) =>
{
    contato.CreatedAt = DateTime.UtcNow;
    contato.UpdatedAt = DateTime.UtcNow;
    db.Contatos.Add(contato);
    await db.SaveChangesAsync();
    return Results.Created($"/contatos/{contato.Id}", contato);
});

app.MapPut("/contatos/{id:int}", async (int id, Contato input, AppDbContext db) =>
{
    var contato = await db.Contatos.FindAsync(id);
    if (contato is null) return Results.NotFound();

    contato.Nome = input.Nome;
    contato.Email = input.Email;
    contato.Telefone = input.Telefone;
    contato.TipoContato = input.TipoContato;
    contato.PessoaId = input.PessoaId;
    contato.UpdatedAt = DateTime.UtcNow;

    await db.SaveChangesAsync();
    return Results.Ok(contato);
});

app.MapDelete("/contatos/{id:int}", async (int id, AppDbContext db) =>
{
    var contato = await db.Contatos.FindAsync(id);
    if (contato is null) return Results.NotFound();

    db.Contatos.Remove(contato);
    await db.SaveChangesAsync();
    return Results.NoContent();
});

app.Run();
