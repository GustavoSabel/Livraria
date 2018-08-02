using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Infra
{
    public class BookstoreContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Bookstore;Trusted_Connection=True;");
            //base.OnConfiguring(optionsBuilder);
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public BookstoreContext() { }

        public void ExecuteMigrations()
        {
            Database.EnsureCreated();
            Database.Migrate();
        }
    }
}
