using pessoa_service.Abstractions;
using PessoaService.Infrastructure.Persistence.Context;
namespace pessoa_service.Features.Pessoas.ExcluirPessoa;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
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
