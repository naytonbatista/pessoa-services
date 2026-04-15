using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PessoaService.Infrastructure.Persistence.Context;
using PessoaService.Application.Interfaces.Repositories;
using PessoaService.Infrastructure.Persistence.Repositories;


namespace PessoaService.Infrastructure.Extensions
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

