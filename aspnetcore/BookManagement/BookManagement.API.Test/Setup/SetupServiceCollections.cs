using BookManagement.Application;
using BookManagement.Domain;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookManagement.API.Test.Setup;

public static class SetupServiceCollections
{
    private static readonly IServiceCollection ServiceCollectionInstance = new ServiceCollection();
    
    public static IServiceProvider GetContainerInstance()
    {
        if (ServiceCollectionInstance.Count > 0)
        {
            return ServiceCollectionInstance.BuildServiceProvider();
        }
        
        var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
            .Build();
        
        ServiceCollectionInstance.AddApplicationServiceCollections(configuration);
        EnsureDbCreated(configuration);
        
        return ServiceCollectionInstance.BuildServiceProvider();
    }

    private static void EnsureDbCreated(IConfiguration configuration)
    {
        var connection = new SqliteConnection(configuration.GetConnectionString("Default"));
        connection.Open();

        var options = new DbContextOptionsBuilder<BookManagementDbContext>()
            .UseSqlite(connection)
            .Options;

        using var context = new BookManagementDbContext(options);
        context.Database.EnsureCreated();
    }
}