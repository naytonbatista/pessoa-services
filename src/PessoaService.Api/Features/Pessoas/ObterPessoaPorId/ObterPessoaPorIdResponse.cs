namespace pessoa_service.Features.Pessoas.ObterPessoaPorId;

public record ObterPessoaPorIdResponse(
    int Id,
    string Nome,
    string Email,
    string Telefone,
    int Idade,
    bool Ativo
);
