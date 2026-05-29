using PessoaRead.Application.Abstractions.Repository;
using PessoaRead.Application.Features.GetAll;
using PessoaRead.Infrastructure.Persistence.Models;

namespace PessoaRead.Infrastructure.Persistence.Repositories;


public class PessoaRepository : IPessoaRepository
{
    private readonly PessoaReadDbContext _context;

    public PessoaRepository(PessoaReadDbContext context)
    {
        _context = context;
    }


    public Task<IEnumerable<PessoaResponse>> GetAllAsync(CancellationToken cancellationToken)
    {
        var pessoas = _context.Pessoas
            .Select(p => new PessoaResponse
            {
                Id = p.Id,
                NomeCompleto = p.NomeCompleto,
                DataNascimento = p.DataNascimento,
                CPF = p.CPF,
                RG = p.RG,
                Sexo = p.Sexo,
                EstadoCivil = p.EstadoCivil,
                Nacionalidade = p.Nacionalidade,
                
            })
            .ToList();

        return Task.FromResult(pessoas.AsEnumerable());
    }
}
