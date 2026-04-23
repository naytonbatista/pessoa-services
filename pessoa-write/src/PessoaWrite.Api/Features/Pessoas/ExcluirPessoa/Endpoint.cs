using PessoaWrite.Abstractions;
using PessoaWrite.Infrastructure.Persistence.Context;
namespace PessoaWrite.Features.Pessoas.ExcluirPessoa;

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
