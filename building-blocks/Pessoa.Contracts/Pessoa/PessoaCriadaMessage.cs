namespace Pessoa.Contracts.Pessoa;

public sealed record PessoaCriadaMessage(
    Guid Id,
    string NomeCompleto,
    DateTime DataNascimento,
    string CPF,
    string RG,
    string Sexo,
    string EstadoCivil,
    string Nacionalidade,
    DateTime DataCriacao);
