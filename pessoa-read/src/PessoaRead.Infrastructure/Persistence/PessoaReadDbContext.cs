using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;
using PessoaRead.Infrastructure.Persistence.Models;

namespace PessoaRead.Infrastructure.Persistence;
public class PessoaReadDbContext(DbContextOptions<PessoaReadDbContext> options) : DbContext(options)
{
    public DbSet<PessoaReadModel> Pessoas => Set<PessoaReadModel>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PessoaReadModel>().ToCollection("Pessoas");

        modelBuilder.Entity<PessoaReadModel>(entity =>
        {
            entity.HasKey(e => e.Id);

        });
    }

}