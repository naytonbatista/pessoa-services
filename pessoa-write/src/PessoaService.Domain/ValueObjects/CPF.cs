using PessoaService.Domain.Exceptions;

namespace PessoaService.Domain.ValueObjects;

public record CPF
{
    public string Valor { get; }

    public CPF(string valor)
    {
        if (string.IsNullOrWhiteSpace(valor))
            throw new DomainException("O CPF não pode ser vazio.");

        var cpfLimpo = RemoverMascara(valor);

        if (!CpfValido(cpfLimpo))
            throw new DomainException("CPF inválido.");

        if (cpfLimpo.Length != 11 || !cpfLimpo.All(char.IsDigit))
            throw new DomainException("CPF deve conter exatamente 11 dígitos numéricos.");

        Valor = cpfLimpo;

    }

    public override string ToString() => Convert.ToUInt64(Valor).ToString(@"000\.000\.000\-00");

    private static string RemoverMascara(string valor) => new([.. valor.Where(char.IsDigit)]);

    private static bool CpfValido(string cpf)
    {
        if (cpf.Length != 11 || cpf.Distinct().Count() == 1)
            return false;

        var numeros = cpf.Select(c => int.Parse(c.ToString())).ToArray();

        var soma1 = Enumerable.Range(0, 9).Sum(i => numeros[i] * (10 - i));
        var digito1 = soma1 % 11 < 2 ? 0 : 11 - (soma1 % 11);

        var soma2 = Enumerable.Range(0, 10).Sum(i => numeros[i] * (11 - i));
        var digito2 = soma2 % 11 < 2 ? 0 : 11 - (soma2 % 11);

        return digito1 == numeros[9] && digito2 == numeros[10];
    }

}
