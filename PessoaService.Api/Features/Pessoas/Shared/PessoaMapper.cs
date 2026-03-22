using pessoa_service.Features.Pessoas;
using pessoa_service.Features.Pessoas.AtualizarPessoa;
using pessoa_service.Features.Pessoas.CriarPessoa;
using pessoa_service.Features.Pessoas.ObterPessoaPorId;
using pessoa_service.Features.Pessoas.ObterPessoas;
using pessoa_service.Models;

namespace pessoa_service.Features.Pessoas
{
    public static class PessoaMapper
    {

        public static Pessoa ToEntity(this CriarPessoaRequest request)
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
        public static void UpdateEntity(this Pessoa pessoa, AtualizarPessoaRequest request)
        {
            pessoa.Nome = request.Nome;
            pessoa.Email = request.Email;
            pessoa.Telefone = request.Telefone;
            pessoa.DataNascimento = request.DataNascimento;
            pessoa.Ativo = request.Ativo;
            pessoa.UpdatedAt = DateTime.UtcNow;
        }

        public static CriarPessoaResponse ToCriarPessoaResponse(this Pessoa pessoa)
        {
            return new CriarPessoaResponse(
                pessoa.Id,
                pessoa.Nome,
                pessoa.Email,
                pessoa.Telefone,
                pessoa.Idade,
                pessoa.Ativo
            );
        }

        public static AtualizarPessoaResponse ToAtualizarPessoaResponse(this Pessoa pessoa)
        {
            return new AtualizarPessoaResponse(
                pessoa.Id,
                pessoa.Nome,
                pessoa.Email,
                pessoa.Telefone,
                pessoa.Idade,
                pessoa.Ativo
            );
        }

        public static ObterPessoasResponse ToObterPessoasResponse(this Pessoa pessoa)
        {
            return new ObterPessoasResponse(
                pessoa.Id,
                pessoa.Nome,
                pessoa.Email,
                pessoa.Telefone,
                pessoa.Idade,
                pessoa.Ativo
            );
        }

        public static ObterPessoaPorIdResponse ToObterPessoaPorIdResponse(this Pessoa pessoa)
        {
            return new ObterPessoaPorIdResponse(
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
