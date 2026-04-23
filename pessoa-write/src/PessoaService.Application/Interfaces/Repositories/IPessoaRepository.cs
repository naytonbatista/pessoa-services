using PessoaService.Domain.Entities;

namespace PessoaService.Application.Interfaces.Repositories;

public interface IPessoaRepository
{
    Task AdicionarAsync(Pessoa pessoa, CancellationToken cancellationToken = default);
    Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Pessoa>> ObterTodosAsync(CancellationToken cancellationToken = default);
    Task AtualizarAsync(Pessoa pessoa, CancellationToken cancellationToken = default);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken = default);
}