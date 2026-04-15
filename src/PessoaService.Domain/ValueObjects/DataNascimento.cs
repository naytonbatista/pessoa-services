namespace PessoaService.Domain.ValueObjects;

public record DataNascimento
{
    public DateTime Valor { get; }

    public DataNascimento(DateTime valor)
    {
        if (valor == default)
            throw new ArgumentException("Data de nascimento inválida.");

        if (valor > DateTime.UtcNow)
            throw new ArgumentException("A data de nascimento não pode ser no futuro.");

        if (valor < DateTime.UtcNow.AddYears(-150))
            throw new ArgumentException("A data de nascimento não pode ser há mais de 150 anos.");

        Valor = valor.Date;
    }

    public int CalcularIdade()
    {
        var hoje = DateTime.UtcNow;
        var idade = hoje.Year - Valor.Year;

        if (Valor.Date > hoje.AddYears(-idade)) idade--;

        return idade;
    }
}
