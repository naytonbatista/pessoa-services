using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Contatos.CriarContato;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/contatos", async (CriarContatoRequest request, AppDbContext db) =>
        {
            var contato = request.ToEntity();

            db.Contatos.Add(contato);
            await db.SaveChangesAsync();

            return Results.Created($"/contatos/{contato.Id}", contato.ToCriarContatoResponse());
        });
    }
}
