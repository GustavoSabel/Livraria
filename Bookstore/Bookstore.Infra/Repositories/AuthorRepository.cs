using Bookstore.Domain.Entities;
using Bookstore.Domain.Queries;
using Bookstore.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Infra.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public IReadOnlyList<AuthorListQuery> GetAll()
        {
            using (var db = new BookstoreContext())
            {
                var lista = db.Authors
                    .Select(x => new AuthorListQuery()
                    {
                        FirstName = x.FirstName,
                        LastName = x.LastName,
                        Birthdate = x.Birthdate,
                    })
                    .ToList();
                return lista;
            }
        }
    }
}
