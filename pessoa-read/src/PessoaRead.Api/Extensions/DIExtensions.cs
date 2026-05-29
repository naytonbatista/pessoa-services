namespace PessoaRead.Api.Extensions;

public static class DIExtensions
{
    public static void AddEndpoints(this IServiceCollection services)
    {
        services.Scan(scan => scan
            .FromAssemblies(typeof(DIExtensions).Assembly)
            .AddClasses(classes => classes.AssignableTo<Abstractions.IEndpoint>()) 
            .AsImplementedInterfaces()
            .WithSingletonLifetime());
    }

}