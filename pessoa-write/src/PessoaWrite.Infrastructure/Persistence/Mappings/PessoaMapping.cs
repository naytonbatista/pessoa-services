using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PessoaWrite.Domain.ValueObjects;
using PessoaEntity = PessoaWrite.Domain.Entities.Pessoa;

namespace PessoaWrite.Infrastructure.Persistence.Mappings;

public sealed class PessoaMapping : IEntityTypeConfiguration<PessoaEntity>
{
    private static DateTime? ToProvider(DataAtualizacao? dataAtualizacao) =>
        dataAtualizacao is { } valor ? valor.Valor : null;

    private static DataAtualizacao? FromProvider(DateTime? valor) =>
        valor.HasValue ? new DataAtualizacao(valor.Value) : null;

    public void Configure(EntityTypeBuilder<PessoaEntity> builder)
    {
        var dataAtualizacaoConverter = new ValueConverter<DataAtualizacao?, DateTime?>(
            dataAtualizacao => ToProvider(dataAtualizacao),
            valor => FromProvider(valor));

        builder.ToTable("Pessoas");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .ValueGeneratedNever();

        builder.Property(p => p.NomeCompleto)
            .HasConversion(
                nomeCompleto => nomeCompleto.Valor,
                valor => new NomeCompleto(valor))
            .HasColumnName("NomeCompleto")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(p => p.DataNascimento)
            .HasConversion(
                dataNascimento => dataNascimento.Valor,
                valor => new DataNascimento(valor))
            .HasColumnName("DataNascimento")
            .IsRequired();

        builder.Property(p => p.CPF)
            .HasConversion(
                cpf => cpf.Valor,
                valor => new CPF(valor))
            .HasColumnName("CPF")
            .HasMaxLength(14)
            .IsRequired();

        builder.Property(p => p.RG)
            .HasConversion(
                rg => rg.Valor,
                valor => new RG(valor))
            .HasColumnName("RG")
            .HasMaxLength(20)
            .IsRequired();

        builder.Property(p => p.Sexo)
            .HasConversion(
                sexo => sexo.Valor,
                valor => new Sexo(valor))
            .HasColumnName("Sexo")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.EstadoCivil)
            .HasConversion(
                estadoCivil => estadoCivil.Valor,
                valor => new EstadoCivil(valor))
            .HasColumnName("EstadoCivil")
            .HasMaxLength(50)
            .IsRequired();

        builder.Property(p => p.Nacionalidade)
            .HasConversion(
                nacionalidade => nacionalidade.Valor,
                valor => new Nacionalidade(valor))
            .HasColumnName("Nacionalidade")
            .HasMaxLength(100)
            .IsRequired();

        builder.Property(p => p.DataCriacao)
            .HasConversion(
                dataCriacao => dataCriacao.Valor,
                valor => new DataCriacao(valor))
            .HasColumnName("DataCriacao")
            .IsRequired();

        builder.Property(p => p.DataAtualizacao)
            .HasConversion(dataAtualizacaoConverter)
            .HasColumnName("DataAtualizacao")
            .IsRequired(false);
    }
}
