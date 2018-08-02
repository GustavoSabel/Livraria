using Bookstore.Domain.Entities;
using Bookstore.Domain.Queries;
using Bookstore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Infra.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext contexto) : base(contexto)
        {
        }

        public IReadOnlyList<BookListQuery> GetAll()
        {
            var lista = _contexto.Books
                .Include(x => x.Author)
                .AsNoTracking()
                .Select(x => new BookListQuery()
                {
                    Title = x.Title,
                    AuthorId = x.AuthorId,
                    AuthorName = x.Author.FullName
                })
                .ToList();
            return lista;
        }
    }
}
