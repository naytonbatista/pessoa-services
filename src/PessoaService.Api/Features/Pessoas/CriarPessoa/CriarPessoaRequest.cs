namespace pessoa_service.Features.Pessoas.CriarPessoa;

public record CriarPessoaRequest(
    string Nome,
    string Email,
    string Telefone,
    DateTime DataNascimento,
    bool Ativo = true
);
