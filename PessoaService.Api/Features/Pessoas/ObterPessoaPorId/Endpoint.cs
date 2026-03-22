using Microsoft.EntityFrameworkCore;
using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Pessoas.ObterPessoaPorId;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/pessoas/{id:int}", async (int id, AppDbContext db) =>
        {
            var pessoa = await db.Pessoas
                .Include(p => p.Contatos)
                .FirstOrDefaultAsync(p => p.Id == id);

            return pessoa is not null
                ? Results.Ok(pessoa.ToObterPessoaPorIdResponse())
                : Results.NotFound();
        });
    }
}
