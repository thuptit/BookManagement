using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain
{
    public class BookManagementContextFactory : IDesignTimeDbContextFactory<BookManagementDbContext>
    {
        public BookManagementDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<BookManagementDbContext>();

            var currentLocation = Assembly.GetExecutingAssembly().Location;
            var rootPathMachine = currentLocation.Split("BookManagement");
            var basePathConfig = Path.Combine(rootPathMachine[0], "BookManagement", "aspnetcore", "BookManagement", "BookManagement.API");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(basePathConfig)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json",optional: true)
                .Build();

            optionsBuilder.UseSqlite(configuration.GetConnectionString("Default"));

            return new BookManagementDbContext(optionsBuilder.Options);
        }
    }
}
