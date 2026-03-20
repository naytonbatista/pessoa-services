using Microsoft.EntityFrameworkCore;
using pessoa_service.Data;
using pessoa_service.Models;

namespace pessoa_service.Features.Pessoas
{
    public static class PessoaEndpoints
    {
        public static void MapPessoaEndpoints(this WebApplication app)
        {
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
        }
    }
}