using MassTransit;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace PessoaRead.Infrastructure.DependencyInjection;


public static class RabbitMqDependencyInjection
{
    public static void AddRabbitMq(this IServiceCollection services, IConfiguration configuration)
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
}