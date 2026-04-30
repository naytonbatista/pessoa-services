using Microsoft.EntityFrameworkCore;
using PessoaWrite.Infrastructure.Persistence.Mappings;
using PessoaEntity = PessoaWrite.Domain.Entities.Pessoa;

namespace PessoaWrite.Infrastructure.Persistence.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<PessoaEntity> Pessoas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PessoaMapping());
    }
}
