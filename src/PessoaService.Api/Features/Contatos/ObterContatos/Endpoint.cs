using Microsoft.EntityFrameworkCore;
using pessoa_service.Abstractions;
using pessoa_service.Data;

namespace pessoa_service.Features.Contatos.ObterContatos;

public class Endpoint : IEndpoint
{
    public void MapEndpoints(IEndpointRouteBuilder app)
    {
        app.MapGet("/contatos", async (AppDbContext db) =>
        {
            var contatos = await db.Contatos.Include(c => c.Pessoa).ToListAsync();
            return contatos.Select(c => c.ToObterContatosResponse()).ToList();
        });
    }
}
