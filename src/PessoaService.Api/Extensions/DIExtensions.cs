using Scrutor;

namespace pessoa_service.Extensions
{
    public static class DIExtensions
    {
        public static void AddEndpoints(this IServiceCollection services)
        {
            // Add application services using assembly scanning with Scrutor
            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.AssignableTo<Abstractions.IEndpoint>()) 
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
        }
    }
}
