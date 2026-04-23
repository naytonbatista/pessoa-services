using PessoaWrite.Abstractions;
using PessoaWrite.Features.Pessoas;
using MediatR;

namespace PessoaWrite.Features.Pessoas.CriarPessoa;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPost("/pessoas", async (CriarPessoaRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = PessoaMapper.Parse(request);

            await sender.Send(command, cancellationToken);

            return Results.Ok("Pessoa criada com sucesso.");
        });
    }
}
