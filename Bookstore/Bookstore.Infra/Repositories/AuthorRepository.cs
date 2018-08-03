using Bookstore.Domain.Entities;
using Bookstore.Domain.Queries;
using Bookstore.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Bookstore.Infra.Repositories
{
    public class AuthorRepository : Repository<Author>, IAuthorRepository
    {
        public AuthorRepository(BookstoreContext contexto) : base(contexto)
        {
        }

        public IReadOnlyList<AuthorListQuery> GetAll()
        {
            var lista = _contexto.Authors
                .OrderBy(x => x.FirstName)
                .Select(x => new AuthorListQuery()
                {
                    Id = x.Id,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Birthdate = x.Birthdate,
                })
                .ToList();
            return lista;
        }
    }
}
