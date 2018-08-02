using Bookstore.Infra;

namespace Bookstore.Test.Repositories
{
    public class RepositoryTest
    {
        private BookstoreContext _contexto;

        public RepositoryTest()
        {
            _contexto = new BookstoreContext();
            _contexto.Database.EnsureCreated();
        }
    }
}
