using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pessoa_service.Models;

namespace pessoa_service.Data.Mappings
{
    public sealed class PessoaMapping : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> entity)
        {
            entity.ToTable("Pessoas");
            entity.HasKey(p => p.Id);

            entity.Property(p => p.Nome)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(p => p.Email)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(p => p.Telefone)
                .HasMaxLength(30);

            entity.Property(p => p.DataNascimento)
                .IsRequired();

            entity.Property(p => p.Ativo)
                .IsRequired();

            entity.Property(p => p.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(p => p.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.HasMany(p => p.Contatos)
                .WithOne(c => c.Pessoa)
                .HasForeignKey(c => c.PessoaId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
