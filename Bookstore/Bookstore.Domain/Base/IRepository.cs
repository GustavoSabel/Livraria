using System;

namespace Bookstore.Domain.Base
{
    public interface IRepository<T> where T : Entity
    {
        T Get(Guid id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(Guid id);
    }
}
