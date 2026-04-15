namespace PessoaService.Domain.ValueObjects;

public record NomeCompleto
{
    public string Valor { get; }

    public NomeCompleto(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("O nome completo não pode ser vazio.");

        if (valor.Trim().Length < 3)
            throw new ArgumentException("O nome completo deve ter pelo menos 3 caracteres.");

        if (!valor.Contains(" "))
            throw new ArgumentException("Informe o nome completo, incluindo pelo menos um sobrenome.");


        Valor = valor.Trim();
    }
}
