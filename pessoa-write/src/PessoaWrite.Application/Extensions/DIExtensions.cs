using Microsoft.Extensions.DependencyInjection;
using PessoaWrite.Application.Features.Pessoas.CriarPessoa;

public static class DIExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DIExtensions).Assembly));

        services.Scan(scan =>scan
            .FromAssemblies(typeof(DIExtensions).Assembly)
            .AddClasses(classes => classes.Where(type => type.Name.EndsWith("Validator")))
            .AsSelf()
            .WithScopedLifetime());
        return services;
    }

}
