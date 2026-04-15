using pessoa_service.Features.Pessoas.AtualizarPessoa;
using pessoa_service.Features.Pessoas.CriarPessoa;
using pessoa_service.Features.Pessoas.ObterPessoaPorId;
using pessoa_service.Features.Pessoas.ObterPessoas;
using PessoaService.Application.Features.Pessoas.CriarPessoa;

namespace pessoa_service.Features.Pessoas
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
    }
}
