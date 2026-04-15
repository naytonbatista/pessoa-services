using Microsoft.EntityFrameworkCore;
using PessoaService.Domain.Entities;
using PessoaService.Infrastructure.Persistence.Mappings;

namespace PessoaService.Infrastructure.Persistence.Context;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<Pessoa> Pessoas { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfiguration(new PessoaMapping());
    }
}
