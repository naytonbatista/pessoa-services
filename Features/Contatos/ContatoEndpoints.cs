using Microsoft.EntityFrameworkCore;
using pessoa_service.Abstractions;
using pessoa_service.Data;
using pessoa_service.Models;

namespace pessoa_service.Features.Contatos
{
    public class ContatoEndpoints : IEndpoint
    {
        public void MapEndpoints(IEndpointRouteBuilder app)
        {
            app.MapGet("/contatos", async (AppDbContext db) =>
            {
                var contatos = await db.Contatos.Include(c => c.Pessoa).ToListAsync();
                return contatos.Select(c => c.ToResponse()).ToList();
            });

            app.MapGet("/contatos/{id:int}", async (int id, AppDbContext db) =>
            {
                var contato = await db.Contatos.Include(c => c.Pessoa).FirstOrDefaultAsync(c => c.Id == id);
                return contato is not null ? Results.Ok(contato.ToResponse()) : Results.NotFound();
            });

            app.MapPost("/contatos", async (ContatoRequest request, AppDbContext db) =>
            {
                var contato = request.ToEntity();
                contato.CreatedAt = DateTime.UtcNow;
                contato.UpdatedAt = DateTime.UtcNow;
                db.Contatos.Add(contato);
                await db.SaveChangesAsync();
                return Results.Created($"/contatos/{contato.Id}", contato.ToResponse());
            });

            app.MapPut("/contatos/{id:int}", async (int id, ContatoRequest request, AppDbContext db) =>
            {
                var contato = await db.Contatos.FindAsync(id);
                if (contato is null) return Results.NotFound();

                contato.UpdateEntity(request);
                contato.UpdatedAt = DateTime.UtcNow;

                await db.SaveChangesAsync();
                return Results.Ok(contato.ToResponse());
            });

            app.MapDelete("/contatos/{id:int}", async (int id, AppDbContext db) =>
            {
                var contato = await db.Contatos.FindAsync(id);
                if (contato is null) return Results.NotFound();

                db.Contatos.Remove(contato);
                await db.SaveChangesAsync();
                return Results.NoContent();
            });
        }
    }
}