using Pessoa.Contracts.Pessoa;
using PessoaRead.Infrastructure.Persistence.Models;

public static class PessoaMapper
{
    public static PessoaReadModel ToReadModel(this PessoaCriadaMessage message)
    {
        return new PessoaReadModel
        {
            Id = message.Id,
            NomeCompleto = message.NomeCompleto,
            DataNascimento = message.DataNascimento,
            CPF = message.CPF,
            RG = message.RG,
            Sexo = message.Sexo,
            EstadoCivil = message.EstadoCivil,
            Nacionalidade = message.Nacionalidade,
            DataCriacao = message.DataCriacao,
            DataAtualizacao = null
        };
    }
}
