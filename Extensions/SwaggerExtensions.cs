using Microsoft.OpenApi.Models;

namespace pessoa_service.Extensions
{
    public static class SwaggerExtensions
    {
        public static void AddSwaggerConfigs(this IServiceCollection services)
        {
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Pessoa Service API",
                    Version = "v1",
                    Description = "API para gerenciamento de pessoas e contatos"
                });
            });
        }

        public static void UseSwaggerConfigs(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Pessoa Service API v1");
                    c.RoutePrefix = string.Empty; // Serve Swagger UI at the root URL
                });
            }
        }
    }
}