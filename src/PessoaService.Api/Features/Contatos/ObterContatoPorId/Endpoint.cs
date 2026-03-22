using Microsoft.EntityFrameworkCore;
using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Contatos.ObterContatoPorId;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/contatos/{id:int}", async (int id, AppDbContext db) =>
        {
            var contato = await db.Contatos
                .Include(c => c.Pessoa)
                .FirstOrDefaultAsync(c => c.Id == id);

            return contato is not null
                ? Results.Ok(contato.ToObterContatoPorIdResponse())
                : Results.NotFound();
        });
    }
}
