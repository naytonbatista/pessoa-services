using PessoaWrite.Domain.Exceptions;

namespace PessoaWrite.Domain.ValueObjects;

public record EstadoCivil
{
    public string Valor { get; }

    public EstadoCivil(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new DomainException("O estado civil não pode ser vazio.");

        var valorNormalizado = valor.Trim().ToUpper();

        var estadosCivisValidos = new[] { "SOLTEIRO", "CASADO", "DIVORCIADO", "VIUVO", "UNIAO ESTAVEL" };

        if (!estadosCivisValidos.Contains(valorNormalizado))
            throw new DomainException($"Estado civil inválido. Os valores válidos são: {string.Join(", ", estadosCivisValidos)}.");

        Valor = valorNormalizado;
    }
}
