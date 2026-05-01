namespace PessoaRead.Infrastructure.Persistence.Models;

public class PessoaReadModel
{
    public Guid Id { get; set; }
    public string NomeCompleto { get; set; } = null!;
    public DateTime DataNascimento { get; set; }
    public string CPF { get; set; } = null!;
    public string RG { get; set; } = null!;
    public string Sexo { get; set; } = null!;

    public string EstadoCivil { get; set; } = null!;
    public string Nacionalidade { get; set; } = null!;
    public DateTime DataCriacao { get; set; }
    public DateTime? DataAtualizacao { get; set; }
}