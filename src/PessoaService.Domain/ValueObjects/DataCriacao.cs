namespace PessoaService.Domain.ValueObjects;

public record DataCriacao
{
    public DateTime Valor { get; }

    public DataCriacao(DateTime valor)
    {
        if (valor > DateTime.UtcNow)
            throw new ArgumentException("A data de criação não pode ser no futuro.");

        Valor = valor;
    }
}
