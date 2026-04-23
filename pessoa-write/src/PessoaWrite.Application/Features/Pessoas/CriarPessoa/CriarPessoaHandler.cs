using MediatR;
using PessoaWrite.Application.Interfaces.Repositories;

namespace PessoaWrite.Application.Features.Pessoas.CriarPessoa;

public sealed class CriarPessoaHandler(IPessoaRepository pessoaRepository, CriarPessoaCommandValidator validator) : IRequestHandler<CriarPessoaCommand, Guid>
{
    private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
    private readonly CriarPessoaCommandValidator _validator = validator;

    public async Task<Guid> Handle(CriarPessoaCommand command, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        cancellationToken.ThrowIfCancellationRequested();

        _validator.ValidateAndThrow(command);

        var pessoa = PessoaMapper.Parse(command);

        await _pessoaRepository.AdicionarAsync(pessoa);

        return pessoa.Id;
    }
}
