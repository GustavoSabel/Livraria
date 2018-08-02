using Bookstore.Domain.Base;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Queries;
using System.Collections.Generic;

namespace Bookstore.Domain.Repositories
{
    public interface IAuthorRepository : IRepository<Author>
    {
        IReadOnlyList<AuthorListQuery> GetAll();
    }
}
