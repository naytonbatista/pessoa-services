namespace pessoa_service.Features.Pessoas.AtualizarPessoa;

public record AtualizarPessoaRequest(
    string Nome,
    string Email,
    string Telefone,
    DateTime DataNascimento,
    bool Ativo = true
);
