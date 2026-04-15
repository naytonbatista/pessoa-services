using Microsoft.EntityFrameworkCore;
using PessoaService.Application.Interfaces.Repositories;
using PessoaService.Domain.Entities;
using PessoaService.Infrastructure.Persistence.Context;
namespace PessoaService.Infrastructure.Persistence.Repositories;


public class PessoaRepository : IPessoaRepository
{
    private readonly AppDbContext _context;

    public PessoaRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task AdicionarAsync(Pessoa pessoa, CancellationToken cancellationToken = default)
    {
        await _context.Pessoas.AddAsync(pessoa, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await _context.Pessoas.FindAsync(id, cancellationToken);
    }

    public async Task<IEnumerable<Pessoa>> ObterTodosAsync(CancellationToken cancellationToken = default)
    {
        return await _context.Pessoas.ToListAsync(cancellationToken);
    }

    public async Task AtualizarAsync(Pessoa pessoa, CancellationToken cancellationToken = default)
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