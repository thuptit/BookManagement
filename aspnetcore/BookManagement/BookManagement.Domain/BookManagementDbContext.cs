using BookManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookManagement.Domain;

public class BookManagementDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }  
    public DbSet<Category> Categories { get; set; }
    public BookManagementDbContext(DbContextOptions<BookManagementDbContext> options) : base(options)
    {
    }
}