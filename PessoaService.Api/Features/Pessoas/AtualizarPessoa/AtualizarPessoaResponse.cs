namespace pessoa_service.Features.Pessoas.AtualizarPessoa;

public record AtualizarPessoaResponse(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    int Idade,
    bool Ativo
);
