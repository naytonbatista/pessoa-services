using PessoaWrite.Application.Validations;
using PessoaWrite.Application.Features.Pessoas.Validator;
using PessoaWrite.Domain.ValueObjects;

namespace PessoaWrite.Application.Features.Pessoas.AtualizarPessoa;

public sealed class AtualizarPessoaCommandValidator : ValidatorCommand
{
    public ValidationDictionary Validate(AtualizarPessoaCommand? command)
    {
        var validations = new ValidationDictionary();

        if (command is null)
        {
            validations.AddError(nameof(AtualizarPessoaCommand), "O comando de atualização de pessoa não pode ser vazio.");
            return validations;
        }

        ValidateId(command, validations);
        ValidateNomeCompleto(command, validations);
        ValidateDataNascimento(command, validations);
        ValidateCPF(command, validations);
        ValidateRG(command, validations);
        ValidateSexo(command, validations);
        ValidateEstadoCivil(command, validations);
        ValidateNacionalidade(command, validations);

        return validations;
    }

    public void ValidateAndThrow(AtualizarPessoaCommand? command)
    {
        var validations = Validate(command);
        ThrowIfInvalid(validations);
    }

    private static void ValidateId(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        if (command.Id == Guid.Empty)
            validations.AddError(nameof(command.Id), "O id é obrigatório.");
    }

    private static void ValidateNomeCompleto(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.NomeCompleto), command.NomeCompleto, validations);

        if (!string.IsNullOrWhiteSpace(command.NomeCompleto))
            ValidateDomainValue(nameof(command.NomeCompleto), () => new NomeCompleto(command.NomeCompleto), validations);
    }

    private static void ValidateDataNascimento(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateDomainValue(nameof(command.DataNascimento), () => new DataNascimento(command.DataNascimento), validations);
    }

    private static void ValidateCPF(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.CPF), command.CPF, validations);

        if (!string.IsNullOrWhiteSpace(command.CPF))
            ValidateDomainValue(nameof(command.CPF), () => new CPF(command.CPF), validations);
    }

    private static void ValidateRG(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.RG), command.RG, validations);
    }

    private static void ValidateSexo(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.Sexo), command.Sexo, validations);

        if (!string.IsNullOrWhiteSpace(command.Sexo))
            ValidateDomainValue(nameof(command.Sexo), () => new Sexo(command.Sexo), validations);
    }

    private static void ValidateEstadoCivil(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.EstadoCivil), command.EstadoCivil, validations);

        if (!string.IsNullOrWhiteSpace(command.EstadoCivil))
            ValidateDomainValue(nameof(command.EstadoCivil), () => new EstadoCivil(command.EstadoCivil), validations);
    }

    private static void ValidateNacionalidade(AtualizarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.Nacionalidade), command.Nacionalidade, validations);

        if (!string.IsNullOrWhiteSpace(command.Nacionalidade))
            ValidateDomainValue(nameof(command.Nacionalidade), () => new Nacionalidade(command.Nacionalidade), validations);
    }
}
