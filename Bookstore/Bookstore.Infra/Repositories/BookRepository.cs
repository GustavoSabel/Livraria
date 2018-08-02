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
        public IReadOnlyList<BookListQuery> GetAll()
        {
            using (var db = new BookstoreContext())
            {
                var lista = db.Books
                    .Include(x => x.Author)
                    .Select(x => new BookListQuery()
                    {
                        Title = x.Title,
                        AuthorId = x.Id,
                        AuthorName = x.Author.FullName
                    })
                    .ToList();
                return lista;
            }
        }
    }
}
