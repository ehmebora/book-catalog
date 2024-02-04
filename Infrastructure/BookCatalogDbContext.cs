using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure
{
    public class BookCatalogDbContext : DbContext
    {
        public BookCatalogDbContext(DbContextOptions options) : base(options)
        {   
        }

        public  DbSet<Book> Book { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
