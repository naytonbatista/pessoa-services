using pessoa_service.Abstractions;
using pessoa_service.Data;
using Microsoft.EntityFrameworkCore;

namespace pessoa_service.Features.Pessoas.ObterPessoas;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/pessoas", async (AppDbContext db) =>
        {
            var pessoas = await db.Pessoas.Include(p => p.Contatos).ToListAsync();
            return pessoas.Select(p => p.ToObterPessoasResponse()).ToList();
        });
    }
}