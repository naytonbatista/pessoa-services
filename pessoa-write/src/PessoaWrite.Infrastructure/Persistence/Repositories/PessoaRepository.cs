using Microsoft.EntityFrameworkCore;
using PessoaWrite.Application.Abstractions.Persistence;
using PessoaWrite.Infrastructure.Persistence.Context;
using PessoaEntity = PessoaWrite.Domain.Entities.Pessoa;
namespace PessoaWrite.Infrastructure.Persistence.Repositories;


public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(PessoaEntity pessoa, CancellationToken cancellationToken = default)
    {
        await _context.Pessoas.AddAsync(pessoa, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<PessoaEntity?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Pessoas.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<PessoaEntity>> ObterTodosAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Pessoas.ToListAsync(cancellationToken);
    }

    public async Task AtualizarAsync(PessoaEntity pessoa, CancellationToken cancellationToken = default)
    {
        _context.Pessoas.Update(pessoa);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task ExcluirAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var pessoa = await ObterPorIdAsync(id, cancellationToken);
        if (pessoa != null)
        {
            _context.Pessoas.Remove(pessoa);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
    

}
