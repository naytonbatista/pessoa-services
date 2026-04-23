using PessoaWrite.Application.Exceptions;
using PessoaWrite.Application.Validations;
using PessoaWrite.Domain.Exceptions;

namespace PessoaWrite.Application.Features.Pessoas.Validator;

public abstract class ValidatorCommand
{
    protected static void ValidateRequiredString(string propertyName, string? value, ValidationDictionary validations)
    {
        if (string.IsNullOrWhiteSpace(value))
            validations.AddError(propertyName, "O campo é obrigatório.");
    }

    protected static void ValidateDomainValue(string propertyName, Action validate, ValidationDictionary validations)
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

    protected static void ThrowIfInvalid(ValidationDictionary validations)
    {
        if (!validations.IsValid)
            throw new ValidationException(validations.ToDictionary());
    }
}
