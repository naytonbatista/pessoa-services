using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Contatos.AtualizarContato;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPut("/contatos/{id:int}", async (int id, AtualizarContatoRequest request, AppDbContext db) =>
        {
            var contato = await db.Contatos.FindAsync(id);
            if (contato is null) return Results.NotFound();

            contato.UpdateEntity(request);

            await db.SaveChangesAsync();
            return Results.Ok(contato.ToAtualizarContatoResponse());
        });
    }
}
