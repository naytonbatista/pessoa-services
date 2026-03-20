namespace pessoa_service.Features.Pessoas
{
    public record PessoaResponse(
        int Id,
        string Nome,
        string Email,
        string Telefone,
        int Idade,
        bool Ativo
    );
}