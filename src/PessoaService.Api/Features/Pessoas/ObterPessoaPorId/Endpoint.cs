using Microsoft.EntityFrameworkCore;
using pessoa_service.Abstractions;
using PessoaService.Infrastructure.Persistence.Context;

namespace pessoa_service.Features.Pessoas.ObterPessoaPorId;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/pessoas/{id:int}", async (int id) =>
        {

            return "null";
        });
    }
}
