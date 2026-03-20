using Microsoft.EntityFrameworkCore;
using pessoa_service.Models;

namespace pessoa_service.Data
{
    public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Pessoa> Pessoas { get; set; } = null!;
        public DbSet<Contato> Contatos { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pessoa>(entity =>
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
            });

            modelBuilder.Entity<Contato>(entity =>
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
            });
        }
    }
}
