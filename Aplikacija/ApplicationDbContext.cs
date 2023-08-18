using Aplikacija.EntityConfigurations;
using Aplikacija.Models;
using Microsoft.EntityFrameworkCore;

namespace Aplikacija
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
       //* protected override void onModelCreating(ModelBuilder modelBuilder)
      
        public DbSet<Book> Books { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Book_Author> Book_Authors { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new BookConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
            modelBuilder.ApplyConfiguration(new Book_AuthorConfiguration());
            modelBuilder.ApplyConfiguration(new AuthorConfiguration());
        }
    }
}
