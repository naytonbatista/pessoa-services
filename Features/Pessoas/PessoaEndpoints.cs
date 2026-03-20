using Microsoft.EntityFrameworkCore;
using pessoa_service.Data;
using pessoa_service.Models;

using pessoa_service.Abstractions;

namespace pessoa_service.Features.Pessoas
{
    public class PessoaEndpoints : IEndpoint
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/pessoas", async (AppDbContext db) =>
            {
                var pessoas = await db.Pessoas.Include(p => p.Contatos).ToListAsync();
                return pessoas.Select(p => p.ToResponse()).ToList();
            });

            app.MapGet("/pessoas/{id:int}", async (int id, AppDbContext db) =>
            {
                var pessoa = await db.Pessoas.Include(p => p.Contatos).FirstOrDefaultAsync(p => p.Id == id);
                return pessoa is not null ? Results.Ok(pessoa.ToResponse()) : Results.NotFound();
            });

            app.MapPost("/pessoas", async (PessoaRequest request, AppDbContext db) =>
            {
                var pessoa = request.ToEntity();
                pessoa.CreatedAt = DateTime.UtcNow;
                pessoa.UpdatedAt = DateTime.UtcNow;
                db.Pessoas.Add(pessoa);
                await db.SaveChangesAsync();
                return Results.Created($"/pessoas/{pessoa.Id}", pessoa.ToResponse());
            });

            app.MapPut("/pessoas/{id:int}", async (int id, PessoaRequest request, AppDbContext db) =>
            {
                var pessoa = await db.Pessoas.FindAsync(id);
                if (pessoa is null) return Results.NotFound();

                pessoa.UpdateEntity(request);
                pessoa.UpdatedAt = DateTime.UtcNow;

                await db.SaveChangesAsync();
                return Results.Ok(pessoa.ToResponse());
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