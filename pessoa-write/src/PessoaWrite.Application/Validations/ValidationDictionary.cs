namespace PessoaWrite.Application.Validations;

public sealed class ValidationDictionary
{
    private readonly Dictionary<string, List<string>> _errors = new();

    public bool IsValid => !_errors.Any();

    public void AddError(string propertyName, string errorMessage)
    {
        if (!_errors.ContainsKey(propertyName))
        {
            _errors[propertyName] = new List<string>();
        }
        _errors[propertyName].Add(errorMessage);
    }

    public Dictionary<string, string[]> ToDictionary()
    {
        return _errors.ToDictionary(kvp => kvp.Key, kvp => kvp.Value.ToArray());
    }
}
