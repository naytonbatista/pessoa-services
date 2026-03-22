namespace pessoa_service.Features.Pessoas.CriarPessoa;

public record CriarPessoaResponse(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    int Idade,
    bool Ativo
);
