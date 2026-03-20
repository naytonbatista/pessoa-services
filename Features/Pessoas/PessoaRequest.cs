namespace pessoa_service.Features.Pessoas
{
    public record PessoaRequest(
        string Nome,
        string Email,
        string Telefone,
        DateTime DataNascimento,
        bool Ativo = true
    );
}