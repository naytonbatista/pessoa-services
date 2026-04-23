namespace PessoaWrite.Features.Pessoas.AtualizarPessoa;

public record AtualizarPessoaRequest(
    string NomeCompleto,
    DateTime DataNascimento,
    string CPF,
    string RG,
    string Sexo,
    string EstadoCivil,
    string Nacionalidade
);
