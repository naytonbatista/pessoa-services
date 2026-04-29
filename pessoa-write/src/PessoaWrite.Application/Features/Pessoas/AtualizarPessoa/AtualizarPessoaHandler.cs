using MediatR;
using PessoaWrite.Application.Abstractions.Persistence;
using PessoaWrite.Domain.ValueObjects;

namespace PessoaWrite.Application.Features.Pessoas.AtualizarPessoa;

public sealed class AtualizarPessoaHandler(IPessoaRepository pessoaRepository, AtualizarPessoaCommandValidator validator) : IRequestHandler<AtualizarPessoaCommand, Guid>
{
    private readonly IPessoaRepository _pessoaRepository = pessoaRepository;
    private readonly AtualizarPessoaCommandValidator _validator = validator;
    public async Task<Guid> Handle(AtualizarPessoaCommand command, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(command);
        cancellationToken.ThrowIfCancellationRequested();

        _validator.ValidateAndThrow(command);

        var pessoa = await _pessoaRepository.ObterPorIdAsync(command.Id, cancellationToken);

        if (pessoa is null)
            throw new KeyNotFoundException($"Pessoa com id '{command.Id}' não encontrada.");

        pessoa.Atualizar(
            new NomeCompleto(command.NomeCompleto),
            new DataNascimento(command.DataNascimento),
            new CPF(command.CPF),
            new RG(command.RG),
            new Sexo(command.Sexo),
            new EstadoCivil(command.EstadoCivil),
            new Nacionalidade(command.Nacionalidade));

        await _pessoaRepository.AtualizarAsync(pessoa, cancellationToken);

        return pessoa.Id;
    }
}
