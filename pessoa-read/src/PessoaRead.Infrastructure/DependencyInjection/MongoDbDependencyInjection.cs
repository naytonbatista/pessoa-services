using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using PessoaRead.Infrastructure.Persistence.Models;

namespace PessoaRead.Infrastructure.DependencyInjection;


public static class MongoDbDependencyInjection
{
    public static void AddMongoDb(this IServiceCollection services, IConfiguration configuration)
    {

        var connectionString = configuration.GetConnectionString("MongoDbConnection");
        var databaseName = configuration.GetSection("MongoDb")["DatabaseName"];

        if (string.IsNullOrEmpty(databaseName))
        {
            throw new InvalidOperationException("Database name is not configured.");
        }


        var mongoClient = new MongoClient(connectionString);

        services.AddSingleton<IMongoClient>(mongoClient);
        services.AddSingleton<IMongoDatabase>(sp => sp.GetRequiredService<IMongoClient>().GetDatabase(databaseName));

        services.AddDbContext<PessoaReadDbContext>(options =>
        {
            options.UseMongoDB(mongoClient, databaseName);
        });


    }
}