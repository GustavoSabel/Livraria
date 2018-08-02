using Bookstore.Infra;
using Microsoft.EntityFrameworkCore;

namespace Bookstore.Test.Repositories
{
    public class RepositoryTest
    {
        private static int contador = 0;
        private readonly string _databaseName;
        protected BookstoreContext _contexto;
        private DbContextOptions<BookstoreContext> _options;

        public RepositoryTest()
        {
            _databaseName = "BookStore_" + (contador++);
             ConfigureOptionsDatabaseInMemory();
            _contexto = CriarContexto();
        }

        private void ConfigureOptionsDatabaseInMemory()
        {
            var builder = new DbContextOptionsBuilder<BookstoreContext>();
            builder.UseInMemoryDatabase(_databaseName);
            _options = builder.Options;

            BookstoreContext personDataContext = new BookstoreContext(_options);
            personDataContext.Database.EnsureDeleted();
            personDataContext.Database.EnsureCreated();
        }

        protected BookstoreContext CriarContexto()
        {
            return new BookstoreContext(_options);
        }
    }
}
