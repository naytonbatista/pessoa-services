using PessoaWrite.Application.Exceptions;
using PessoaWrite.Application.Validations;
using PessoaWrite.Domain.Exceptions;
using PessoaWrite.Domain.ValueObjects;

namespace PessoaWrite.Application.Features.Pessoas.CriarPessoa;

public sealed class CriarPessoaCommandValidator
{
    public ValidationDictionary Validate(CriarPessoaCommand? command)
    {
        var validations = new ValidationDictionary();

        if (command is null)
        {
            validations.AddError(nameof(CriarPessoaCommand), "O comando de criação de pessoa não pode ser vazio.");
            return validations;
        }

        ValidateNomeCompleto(command, validations);
        ValidateDataNascimento(command, validations);
        ValidateCPF(command, validations);
        ValidateRG(command, validations);
        ValidateSexo(command, validations);
        ValidateEstadoCivil(command, validations);
        ValidateNacionalidade(command, validations);

        return validations;
    }

    public void ValidateAndThrow(CriarPessoaCommand? command)
    {
        var validations = Validate(command);

        if (!validations.IsValid)
            throw new ValidationException(validations.ToDictionary());
    }

    private static void ValidateNomeCompleto(CriarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.NomeCompleto), command.NomeCompleto, validations);

        if (!string.IsNullOrWhiteSpace(command.NomeCompleto))
            ValidateDomainValue(nameof(command.NomeCompleto), () => new NomeCompleto(command.NomeCompleto), validations);
    }

    private static void ValidateDataNascimento(CriarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateDomainValue(nameof(command.DataNascimento), () => new DataNascimento(command.DataNascimento), validations);
    }

    private static void ValidateCPF(CriarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.CPF), command.CPF, validations);

        if (!string.IsNullOrWhiteSpace(command.CPF))
            ValidateDomainValue(nameof(command.CPF), () => new CPF(command.CPF), validations);
    }

    private static void ValidateRG(CriarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.RG), command.RG, validations);
    }

    private static void ValidateSexo(CriarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.Sexo), command.Sexo, validations);

        if (!string.IsNullOrWhiteSpace(command.Sexo))
            ValidateDomainValue(nameof(command.Sexo), () => new Sexo(command.Sexo), validations);
    }

    private static void ValidateEstadoCivil(CriarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.EstadoCivil), command.EstadoCivil, validations);

        if (!string.IsNullOrWhiteSpace(command.EstadoCivil))
            ValidateDomainValue(nameof(command.EstadoCivil), () => new EstadoCivil(command.EstadoCivil), validations);
    }

    private static void ValidateNacionalidade(CriarPessoaCommand command, ValidationDictionary validations)
    {
        ValidateRequiredString(nameof(command.Nacionalidade), command.Nacionalidade, validations);

        if (!string.IsNullOrWhiteSpace(command.Nacionalidade))
            ValidateDomainValue(nameof(command.Nacionalidade), () => new Nacionalidade(command.Nacionalidade), validations);
    }

    private static void ValidateRequiredString(string propertyName, string? value, ValidationDictionary validations)
    {
        if (string.IsNullOrWhiteSpace(value))
            validations.AddError(propertyName, "O campo é obrigatório.");
    }

    private static void ValidateDomainValue(string propertyName, Action validate, ValidationDictionary validations)
    {
        try
        {
            validate();
        }
        catch (DomainException exception)
        {
            validations.AddError(propertyName, exception.Message);
        }
    }
}
