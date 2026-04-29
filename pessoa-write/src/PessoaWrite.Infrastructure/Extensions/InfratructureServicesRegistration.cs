using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PessoaWrite.Infrastructure.Persistence.Context;
using PessoaWrite.Application.Interfaces.Repositories;
using PessoaWrite.Infrastructure.Persistence.Repositories;
using MassTransit;
using Microsoft.Extensions.Logging;


namespace PessoaWrite.Infrastructure.Extensions
{
    public static class InfrastructureServicesRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IPessoaRepository, PessoaRepository>();

            services.AddMassMessageBus(configuration);

        }

        private static void AddMassMessageBus(this IServiceCollection services, IConfiguration configuration)
        {
            var rabbitMqOptions = configuration.GetSection(nameof(RabbitMqTransportOptions)).Get<RabbitMqTransportOptions>();

            if (rabbitMqOptions == null)
            {
                throw new InvalidOperationException("RabbitMQ não está configurado corretamente. Verifique as configurações no arquivo de configuração. ");
            }

            services.AddOptions<RabbitMqTransportOptions>()
                .Bind(configuration.GetSection(nameof(RabbitMqTransportOptions)))
                .ValidateOnStart();

            services.AddMassTransit(x =>
            {
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqOptions.Host, rabbitMqOptions.Port, rabbitMqOptions.VHost, h =>
                    {
                        h.Username(rabbitMqOptions.User);
                        h.Password(rabbitMqOptions.Pass);
                    });

                });
            });
        }
    }

}

