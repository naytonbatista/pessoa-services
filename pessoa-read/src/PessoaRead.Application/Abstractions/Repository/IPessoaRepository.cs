using PessoaRead.Application.Features.GetAll;

namespace PessoaRead.Application.Abstractions.Repository;

public interface IPessoaRepository
{
    Task<IEnumerable<PessoaResponse>> GetAllAsync(CancellationToken cancellationToken);
}