using pessoa_service.Abstractions;

using Microsoft.EntityFrameworkCore;

namespace pessoa_service.Features.Pessoas.ObterPessoas;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/pessoas",  () =>
        {
            return  "";
        });
    }
}