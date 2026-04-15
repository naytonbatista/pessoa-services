namespace PessoaService.Domain.ValueObjects;

public record DataAtualizacao
{
    public DateTime Valor { get; }

    public DataAtualizacao(DateTime valor)
    {
        if (valor > DateTime.UtcNow)
            throw new ArgumentException("A data de atualização não pode ser no futuro.");

        Valor = valor;
    }
}
