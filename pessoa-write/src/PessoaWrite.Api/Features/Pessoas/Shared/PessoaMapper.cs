using PessoaWrite.Features.Pessoas.AtualizarPessoa;
using PessoaWrite.Features.Pessoas.CriarPessoa;

using PessoaWrite.Application.Features.Pessoas.AtualizarPessoa;
using PessoaWrite.Application.Features.Pessoas.CriarPessoa;

namespace PessoaWrite.Features.Pessoas
{
    public static class PessoaMapper
    {
        public static CriarPessoaCommand Parse(CriarPessoaRequest request) =>
            new(
                request.NomeCompleto,
                request.DataNascimento,
                request.CPF,
                request.RG,
                request.Sexo,
                request.EstadoCivil,
                request.Nacionalidade);

        public static CriarPessoaRequest Parse(CriarPessoaCommand command) =>
            new(
                command.NomeCompleto,
                command.DataNascimento,
                command.CPF,
                command.RG,
                command.Sexo,
                command.EstadoCivil,
                command.Nacionalidade);

        public static AtualizarPessoaCommand Parse(Guid id, AtualizarPessoaRequest request) =>
            new(
                id,
                request.NomeCompleto,
                request.DataNascimento,
                request.CPF,
                request.RG,
                request.Sexo,
                request.EstadoCivil,
                request.Nacionalidade);
    }
}
