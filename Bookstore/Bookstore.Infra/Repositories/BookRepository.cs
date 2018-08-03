using Bookstore.Domain.Entities;
using Bookstore.Domain.Queries;
using Bookstore.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Infra.Repositories
{
    public class BookRepository : Repository<Book>, IBookRepository
    {
        public BookRepository(BookstoreContext contexto) : base(contexto)
        {
        }

        public override Book Get(Guid id)
        {
            return _contexto.Books
                .Include(x => x.Author)
                .FirstOrDefault(x => x.Id == id);
        }

        public IReadOnlyList<BookListQuery> GetAll()
        {
            var lista = _contexto.Books
                .Include(x => x.Author)
                .OrderBy(x => x.Title)
                .Select(x => new BookListQuery()
                {
                    Id = x.Id,
                    Title = x.Title,
                    AuthorId = x.AuthorId,
                    AuthorName = x.Author.FullName
                })
                .ToList();
            return lista;
        }
    }
}
