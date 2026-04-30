using Pessoa.Contracts.Pessoa;
using PessoaWrite.Domain.ValueObjects;
using PessoaEntity = PessoaWrite.Domain.Entities.Pessoa;

namespace PessoaWrite.Application.Features.Pessoas.CriarPessoa;

public static class PessoaMapper
{
    public static PessoaEntity Parse(CriarPessoaCommand command) =>
        new(
            new NomeCompleto(command.NomeCompleto),
            new DataNascimento(command.DataNascimento),
            new CPF(command.CPF),
            new RG(command.RG),
            new Sexo(command.Sexo),
            new EstadoCivil(command.EstadoCivil),
            new Nacionalidade(command.Nacionalidade));

    public static PessoaCriadaMessage ToMessage(PessoaEntity pessoa) =>
        new(
            pessoa.Id,
            pessoa.NomeCompleto.Valor,
            pessoa.DataNascimento.Valor,
            pessoa.CPF.Valor,
            pessoa.RG.Valor,
            pessoa.Sexo.Valor,
            pessoa.EstadoCivil.Valor,
            pessoa.Nacionalidade.Valor,
            pessoa.DataCriacao.Valor);
}
