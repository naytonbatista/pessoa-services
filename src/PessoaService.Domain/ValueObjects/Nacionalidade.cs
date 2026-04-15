namespace PessoaService.Domain.ValueObjects;

public record  Nacionalidade
{
    public string Valor { get; }

    public Nacionalidade(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("A nacionalidade não pode ser vazio.");

        var valorNormalizado = valor.Trim().ToUpper();

        Valor = valorNormalizado;
    }
}
