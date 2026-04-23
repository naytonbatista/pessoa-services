using Microsoft.EntityFrameworkCore;
using PessoaWrite.Domain.Entities;
using PessoaWrite.Infrastructure.Persistence.Mappings;

namespace PessoaWrite.Infrastructure.Persistence.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Pessoa> Pessoas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PessoaMapping());
    }
}
