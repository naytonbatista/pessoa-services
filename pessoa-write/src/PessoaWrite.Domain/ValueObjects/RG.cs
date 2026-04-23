namespace PessoaWrite.Domain.ValueObjects;

public record RG
{
    public string Valor { get; }

    public RG(string valor)
    {
        var valorNormalizado = valor.Trim().ToUpper();

        Valor = valorNormalizado;
    }
}
