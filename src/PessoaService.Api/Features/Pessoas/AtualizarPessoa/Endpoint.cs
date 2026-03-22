using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Pessoas.AtualizarPessoa;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPut("/pessoas/{id:int}", async (int id, AtualizarPessoaRequest request, AppDbContext db) =>
        {
            var pessoa = await db.Pessoas.FindAsync(id);
            if (pessoa is null) return Results.NotFound();

            pessoa.UpdateEntity(request);

            await db.SaveChangesAsync();
            return Results.Ok(pessoa.ToAtualizarPessoaResponse());
        });
    }
}
