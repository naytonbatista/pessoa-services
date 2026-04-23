using Microsoft.Extensions.DependencyInjection;

public static class DIExtensions
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {

            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DIExtensions).Assembly));

            return services;
        }

    }
