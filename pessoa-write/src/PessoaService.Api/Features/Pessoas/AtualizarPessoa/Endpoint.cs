using pessoa_service.Abstractions;

namespace pessoa_service.Features.Pessoas.AtualizarPessoa;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapPut("/pessoas/{id:int}", async (int id, AtualizarPessoaRequest request) =>
        {
            await Task.Delay(100); // Simula uma operação assíncrona, como acesso a banco de dados
            return  Results.Ok("Pessoa atualizada com sucesso.");
        });
    }
}
