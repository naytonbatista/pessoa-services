namespace PessoaWrite.Application.Exceptions;

public sealed class ValidationException : Exception
{

    public Dictionary<string, string[]> Errors { get; }

    public ValidationException(Dictionary<string, string[]> errors) : base("Uma ou mais falhas de validação ocorreram.")
    {
        Errors = errors;
    }
}
