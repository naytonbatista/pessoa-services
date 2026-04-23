using PessoaService.Domain.Entities;
using PessoaService.Domain.ValueObjects;

namespace PessoaService.Application.Features.Pessoas.CriarPessoa;

public static class PessoaMapper
{
    public static Pessoa Parse(CriarPessoaCommand command) =>
        new(
            new NomeCompleto(command.NomeCompleto),
            new DataNascimento(command.DataNascimento),
            new CPF(command.CPF),
            new RG(command.RG),
            new Sexo(command.Sexo),
            new EstadoCivil(command.EstadoCivil),
            new Nacionalidade(command.Nacionalidade));
}
