using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Pessoas.CriarPessoa;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/pessoas", async (CriarPessoaRequest request, AppDbContext db) =>
        {
            var pessoa = request.ToEntity();

            db.Pessoas.Add(pessoa);
            await db.SaveChangesAsync();

            return Results.Created($"/pessoas/{pessoa.Id}", pessoa.ToCriarPessoaResponse());
        });
    }
}
