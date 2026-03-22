using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using pessoa_service.Models;

namespace pessoa_service.Data.Mappings
{
    public sealed class ContatoMapping : IEntityTypeConfiguration<Contato>
    {
        public void Configure(EntityTypeBuilder<Contato> entity)
        {
            entity.ToTable("Contatos");
            entity.HasKey(c => c.Id);

            entity.Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(c => c.Email)
                .HasMaxLength(200);

            entity.Property(c => c.Telefone)
                .HasMaxLength(30);

            entity.Property(c => c.TipoContato)
                .IsRequired();

            entity.Property(c => c.CreatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");

            entity.Property(c => c.UpdatedAt)
                .HasDefaultValueSql("CURRENT_TIMESTAMP");
        }
    }
}
