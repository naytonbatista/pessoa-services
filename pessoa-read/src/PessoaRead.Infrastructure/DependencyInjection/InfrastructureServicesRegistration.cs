using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace PessoaRead.Infrastructure.DependencyInjection
{
    public static class InfrastructureServicesRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMongoDb(configuration);
            services.AddRabbitMq(configuration);
            services.AddRepositories();
            

        }

    }

}

