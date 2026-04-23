using MediatR;
using PessoaService.Application.Interfaces.Repositories;

namespace PessoaService.Application.Features.Pessoas.CriarPessoa;

public sealed class CriarPessoaHandler(IPessoaRepository pessoaRepository) : IRequestHandler<CriarPessoaCommand, Guid>
{
    private readonly IPessoaRepository _pessoaRepository = pessoaRepository;

    public async Task<Guid> Handle(CriarPessoaCommand command, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        cancellationToken.ThrowIfCancellationRequested();

        var pessoa = PessoaMapper.Parse(command);

        await _pessoaRepository.AdicionarAsync(pessoa);

        return pessoa.Id;
    }
}
