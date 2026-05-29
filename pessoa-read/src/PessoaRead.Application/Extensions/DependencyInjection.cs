using Microsoft.Extensions.DependencyInjection;


namespace PessoaRead.Application.Extensions.DependencyInjection;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.Scan(x => x
            .FromAssemblies(typeof(DependencyInjection).Assembly)
            .AddClasses(c => c.InNamespaces("PessoaRead.Application.Features"))
            .AsImplementedInterfaces()
            .WithTransientLifetime());

        return services;
    }
}