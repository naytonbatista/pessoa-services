using MediatR;
using Scrutor;

namespace pessoa_service.Extensions
{
    public static class DIExtensions
    {
        public static void AddEndpoints(this IServiceCollection services)
        {

            services.Scan(scan => scan
                .FromCallingAssembly()
                .AddClasses(classes => classes.AssignableTo<Abstractions.IEndpoint>()) 
                .AsImplementedInterfaces()
                .WithSingletonLifetime());
        }

    }
}
