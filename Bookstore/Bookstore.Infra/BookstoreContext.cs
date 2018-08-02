using Bookstore.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

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

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var idAuthorAdams = new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd1");
            var idAuthorEvans = new Guid("12ded001-2e9e-4917-a1a0-cf21555d4cd2");

            modelBuilder.Entity<Author>().HasData(new Author("Douglas", "Adams", null) { Id = idAuthorAdams });
            modelBuilder.Entity<Author>().HasData(new Author("Eric", "Evans", new DateTime(1945, 07, 02)) { Id = idAuthorEvans });

            modelBuilder.Entity<Book>().HasData(new Book("The Hitchhiker's Guide to the Galaxy", "", idAuthorAdams) { Id = Guid.NewGuid() });
            modelBuilder.Entity<Book>().HasData(new Book("Dirk Gently's Holistic Detective Agency", "", idAuthorAdams) { Id = Guid.NewGuid() });

            modelBuilder.Entity<Book>().HasData(new Book("Domain Driven Design", "", idAuthorEvans) { Id = Guid.NewGuid() });
        }

        public BookstoreContext(DbContextOptions<BookstoreContext> options) : base(options) { }

        public BookstoreContext() { }

        public void ExecuteMigrations()
        {
            //Database.EnsureCreated();
            Database.Migrate();
        }
    }
}
