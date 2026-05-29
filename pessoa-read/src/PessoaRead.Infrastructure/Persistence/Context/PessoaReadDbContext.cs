using Microsoft.EntityFrameworkCore;
using MongoDB.EntityFrameworkCore.Extensions;


namespace PessoaRead.Infrastructure.Persistence.Models;
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