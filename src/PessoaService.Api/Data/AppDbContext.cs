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

            modelBuilder.ApplyConfiguration(new Mappings.PessoaMapping());
            modelBuilder.ApplyConfiguration(new Mappings.ContatoMapping());
        }
    }
}
