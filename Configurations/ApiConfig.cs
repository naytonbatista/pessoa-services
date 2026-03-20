using Microsoft.EntityFrameworkCore;
using pessoa_service.Data;

namespace pessoa_service.Configurations
{
    public static class ApiConfig
    {
        public static void AddApiConfigurations(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
