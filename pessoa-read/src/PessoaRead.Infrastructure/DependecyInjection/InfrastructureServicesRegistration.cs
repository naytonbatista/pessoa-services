using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PessoaRead.Infrastructure.Persistence;
using MongoDB.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;
using MassTransit;

namespace PessoaRead.Infrastructure.Extensions
{
    public static class InfrastructureServicesRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMongoDb(configuration);
            services.AddRabbitMq(configuration);

        }

        private static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
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
                x.AddConsumer<PessoaCriadaConsumer>();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(rabbitMqOptions.Host, rabbitMqOptions.Port, "/", h =>
                    {
                        h.Username(rabbitMqOptions.User);
                        h.Password(rabbitMqOptions.Pass);
                    });

                    cfg.ReceiveEndpoint("pessoa-criada-queue", e =>
                    {
                        e.ConfigureConsumer<PessoaCriadaConsumer>(context);
                    });
                });
            });
        }


        private static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            var databaseName = configuration.GetSection("MongoDb")["DatabaseName"];

            if (string.IsNullOrEmpty(databaseName))
            {
                throw new InvalidOperationException("Database name is not configured.");
            }

            var mongoClient = new MongoDB.Driver.MongoClient(connectionString);

            services.AddDbContext<PessoaReadDbContext>(options =>
            {
                options.UseMongoDB(mongoClient, databaseName);
            });


        }

    }

}

