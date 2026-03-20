using pessoa_service.Features.Pessoas;
using pessoa_service.Models;

namespace pessoa_service.Features.Pessoas
{
    public static class PessoaMapper
    {
        public static Pessoa ToEntity(this PessoaRequest request)
        {
            return new Pessoa
            {
                Nome = request.Nome,
                Email = request.Email,
                Telefone = request.Telefone,
                DataNascimento = request.DataNascimento,
                Ativo = request.Ativo,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };
        }

        public static void UpdateEntity(this Pessoa pessoa, PessoaRequest request)
        {
            pessoa.Nome = request.Nome;
            pessoa.Email = request.Email;
            pessoa.Telefone = request.Telefone;
            pessoa.DataNascimento = request.DataNascimento;
            pessoa.Ativo = request.Ativo;
            pessoa.UpdatedAt = DateTime.UtcNow;
        }

        public static PessoaRequest ToRequest(this Pessoa pessoa)
        {
            return new PessoaRequest(
                pessoa.Nome,
                pessoa.Email,
                pessoa.Telefone,
                pessoa.DataNascimento,
                pessoa.Ativo
            );
        }

        public static PessoaResponse ToResponse(this Pessoa pessoa)
        {
            return new PessoaResponse(
                pessoa.Id,
                pessoa.Nome,
                pessoa.Email,
                pessoa.Telefone,
                pessoa.Idade,
                pessoa.Ativo
            );
        }
    }
}