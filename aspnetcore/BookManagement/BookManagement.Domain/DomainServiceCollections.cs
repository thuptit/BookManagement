using BookManagement.Domain.Repositories.Book;
using BookManagement.Domain.Repositories.Category;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagement.Domain
{
    public static class DomainServiceCollections
    {
        public static void AddDomainServiceCollections(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookManagementDbContext>(options =>
            {
                options.UseSqlite(configuration.GetConnectionString("Default"));
            });
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
        }
    }
}
