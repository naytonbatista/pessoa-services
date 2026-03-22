using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Contatos.ExcluirContato;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
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
