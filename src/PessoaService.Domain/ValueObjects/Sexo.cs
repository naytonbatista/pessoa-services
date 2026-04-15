namespace PessoaService.Domain.ValueObjects;

public record Sexo
{
    public string Valor { get; }

    public Sexo(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("O sexo não pode ser vazio.");

        var valorNormalizado = valor.Trim().ToUpper();

        if (valorNormalizado != "M" && valorNormalizado != "F" && valorNormalizado != "OUTRO")
            throw new ArgumentException("O sexo deve ser 'M', 'F' ou 'Outro'.");

        Valor = valorNormalizado;
    }
}
