using PessoaService.Domain.ValueObjects;

namespace PessoaService.Domain.Entities;

public class Pessoa
{
    public Guid Id { get; private set; }
    public NomeCompleto NomeCompleto { get; private set; } = default!;
    public DataNascimento DataNascimento { get; private set; } = default!;
    public CPF CPF { get; private set; } = default!;
    public RG RG { get; private set; } = default!;
    public Sexo Sexo { get; private set; } = default!;
    public EstadoCivil EstadoCivil { get; private set; } = default!;
    public Nacionalidade Nacionalidade { get; private set; } = default!;
    public DataCriacao DataCriacao { get; private set; } = default!;
    public DataAtualizacao? DataAtualizacao { get; private set; }

    private Pessoa() { }

    public Pessoa(NomeCompleto nomeCompleto, DataNascimento dataNascimento, CPF cpf, RG rg, Sexo sexo, EstadoCivil estadoCivil, Nacionalidade nacionalidade)
    {
        Id = Guid.NewGuid();
        NomeCompleto = nomeCompleto;
        DataNascimento = dataNascimento;
        CPF = cpf;
        RG = rg;
        Sexo = sexo;
        EstadoCivil = estadoCivil;
        Nacionalidade = nacionalidade;
        DataCriacao = new DataCriacao(DateTime.UtcNow);
    }

    public void Atualizar(NomeCompleto nomeCompleto, DataNascimento dataNascimento, CPF cpf, RG rg, Sexo sexo, EstadoCivil estadoCivil, Nacionalidade nacionalidade)
    {
        NomeCompleto = nomeCompleto;
        RG = rg;
        Sexo = sexo;
        EstadoCivil = estadoCivil;
        Nacionalidade = nacionalidade;
        DataAtualizacao = new DataAtualizacao(DateTime.UtcNow);
    }

    public void CorrigirCPF(CPF cpf)
    {
        CPF = cpf;
        DataAtualizacao = new DataAtualizacao(DateTime.UtcNow);
    }

    public void CorrigirDataNascimento(DataNascimento dataNascimento)
    {
        DataNascimento = dataNascimento;
        DataAtualizacao = new DataAtualizacao(DateTime.UtcNow);
    }
}
