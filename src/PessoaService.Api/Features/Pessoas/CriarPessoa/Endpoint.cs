using pessoa_service.Abstractions;
using pessoa_service.Features.Pessoas;
using MediatR;

namespace pessoa_service.Features.Pessoas.CriarPessoa;

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
