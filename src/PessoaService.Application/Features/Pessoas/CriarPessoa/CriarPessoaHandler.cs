using MediatR;

namespace PessoaService.Application.Features.Pessoas.CriarPessoa;

public sealed class CriarPessoaHandler: IRequestHandler<CriarPessoaCommand, Unit>
{
    public async Task<Unit> Handle(CriarPessoaCommand command, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(command);
        cancellationToken.ThrowIfCancellationRequested();

        if (string.IsNullOrWhiteSpace(command.Nome))
            throw new ArgumentException("O nome da pessoa e obrigatorio.", nameof(command));

        if (string.IsNullOrWhiteSpace(command.Email))
            throw new ArgumentException("O email da pessoa e obrigatorio.", nameof(command));

        if (string.IsNullOrWhiteSpace(command.Telefone))
            throw new ArgumentException("O telefone da pessoa e obrigatorio.", nameof(command));

        

        return Unit.Value;
    }
}
