namespace PessoaService.Domain.ValueObjects;

public record EstadoCivil
{
    public string Valor { get; }

    public EstadoCivil(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new ArgumentException("O estado civil não pode ser vazio.");

        var valorNormalizado = valor.Trim().ToUpper();

        var estadosCivisValidos = new[] { "SOLTEIRO", "CASADO", "DIVORCIADO", "VIUVO", "UNIAO ESTAVEL" };

        if (!estadosCivisValidos.Contains(valorNormalizado))
            throw new ArgumentException($"Estado civil inválido. Os valores válidos são: {string.Join(", ", estadosCivisValidos)}.");

        Valor = valorNormalizado;
    }
}
