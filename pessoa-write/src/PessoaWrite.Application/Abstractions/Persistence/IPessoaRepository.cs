using PessoaEntity = PessoaWrite.Domain.Entities.Pessoa;

namespace PessoaWrite.Application.Abstractions.Persistence;

public interface IPessoaRepository
{
    Task AdicionarAsync(PessoaEntity pessoa, CancellationToken cancellationToken = default);
    Task<PessoaEntity?> ObterPorIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task<IEnumerable<PessoaEntity>> ObterTodosAsync(CancellationToken cancellationToken = default);
    Task AtualizarAsync(PessoaEntity pessoa, CancellationToken cancellationToken = default);
    Task ExcluirAsync(Guid id, CancellationToken cancellationToken = default);
}
