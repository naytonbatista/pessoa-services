using MediatR;
using PessoaWrite.Abstractions;
using PessoaWrite.Features.Pessoas;

namespace PessoaWrite.Features.Pessoas.AtualizarPessoa;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPut("/pessoas/{id:guid}", async (Guid id, AtualizarPessoaRequest request, ISender sender, CancellationToken cancellationToken) =>
        {
            var command = PessoaMapper.Parse(id, request);

            await sender.Send(command, cancellationToken);

            return Results.Ok("Pessoa atualizada com sucesso.");
        });
    }
}
