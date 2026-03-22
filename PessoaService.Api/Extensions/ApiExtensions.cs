using Microsoft.EntityFrameworkCore;
using pessoa_service.Data;

namespace pessoa_service.Extensions
{
    public static class ApiExtensions
    {
        public static void AddApiExtensions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}
