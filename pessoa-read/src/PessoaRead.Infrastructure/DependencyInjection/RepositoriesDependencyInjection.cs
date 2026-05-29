using Microsoft.Extensions.DependencyInjection;
using PessoaRead.Application.Abstractions.Repository;
using PessoaRead.Infrastructure.Persistence.Repositories;

namespace PessoaRead.Infrastructure.DependencyInjection;


public static class RepositoriesDependencyInjection
{
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IPessoaRepository, PessoaRepository>();
    }
}