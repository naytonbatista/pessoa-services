using PessoaWrite.Domain.Entities;

namespace PessoaWrite.Application.Abstractions.Persistence;

public interface IPessoaRepository
{
    Task AdicionarAsync(Pessoa pessoa, CancellationToken cancellationToken = default);
    Task<Pessoa?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<Pessoa>> ObterTodosAsync(CancellationToken cancellationToken = default);
    Task AtualizarAsync(Pessoa pessoa, CancellationToken cancellationToken = default);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken = default);
}
