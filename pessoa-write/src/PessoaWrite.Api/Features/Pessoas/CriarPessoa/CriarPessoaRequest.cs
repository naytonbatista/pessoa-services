namespace PessoaWrite.Features.Pessoas.CriarPessoa;

public record CriarPessoaRequest(
    string NomeCompleto,
    DateTime DataNascimento,
    string CPF,
    string RG,
    string Sexo,
    string EstadoCivil,
    string Nacionalidade
);
