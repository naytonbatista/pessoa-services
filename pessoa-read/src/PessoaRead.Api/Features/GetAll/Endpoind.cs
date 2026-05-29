using PessoaRead.Api.Abstractions;
using PessoaRead.Application.Features.GetAll;

namespace PessoaRead.Api.Features.GetAll;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/pessoas", async (IGetPeopleQueryHandler handler, CancellationToken cancellationToken) =>
        {
            var pessoas = await handler.Handle(new GetPeopleQuery(), cancellationToken);

            return Results.Ok(pessoas);
        });
    }
}