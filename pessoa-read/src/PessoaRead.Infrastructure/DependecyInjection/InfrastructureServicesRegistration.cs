using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using PessoaRead.Infrastructure.Persistence;
using MongoDB.EntityFrameworkCore.Extensions;
using Microsoft.EntityFrameworkCore;

namespace PessoaRead.Infrastructure.Extensions
{
    public static class InfrastructureServicesRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddMongoDb(configuration);

        }


        private static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
        {

            var connectionString = configuration.GetConnectionString("MongoDbConnection");
            var databaseName = configuration.GetSection("MongoDb")["DatabaseName"];

            if (string.IsNullOrEmpty(databaseName))
            {
                throw new InvalidOperationException("Database name is not configured.");
            }

            var mongoClient = new MongoDB.Driver.MongoClient(connectionString);

            services.AddDbContext<PessoaReadDbContext>(options =>
            {
                options.UseMongoDB(mongoClient, databaseName);
            });


        }

    }

}

