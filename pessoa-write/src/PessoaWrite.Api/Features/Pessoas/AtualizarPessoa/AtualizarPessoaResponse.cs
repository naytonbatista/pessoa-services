namespace PessoaWrite.Features.Pessoas.AtualizarPessoa;

public record AtualizarPessoaResponse(
    int Id,
    string NomeCompleto,
    DateTime DataNascimento,
    string CPF,
    string RG,
    string Sexo,
    string EstadoCivil,
    string Nacionalidade
);
