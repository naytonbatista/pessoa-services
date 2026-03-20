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
        }
    }
}