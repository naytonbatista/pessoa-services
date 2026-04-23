using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PessoaWrite.Infrastructure.Persistence.Context;
using PessoaWrite.Application.Interfaces.Repositories;
using PessoaWrite.Infrastructure.Persistence.Repositories;


namespace PessoaWrite.Infrastructure.Extensions
{
    public static class InfrastructureServicesRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPessoaRepository, PessoaRepository>();
            

        }
    }

}

