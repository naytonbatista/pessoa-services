namespace pessoa_service.Features.Pessoas.ObterPessoas
{

    public record ObterPessoasResponse(
         int Id,
            string Nome,
            string Email,
            string Telefone,
            int Idade,
            bool Ativo
        );
}
