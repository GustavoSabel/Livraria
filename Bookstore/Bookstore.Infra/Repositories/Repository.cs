using Bookstore.Domain.Base;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Bookstore.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected BookstoreContext _contexto;

        public Repository(BookstoreContext contexto)
        {
            _contexto = contexto;
        }

        public virtual T Get(Guid id)
        {
            return _contexto
                .Set<T>()
                .FirstOrDefault(x => x.Id == id);
        }

        public T Insert(T entity)
        {
            _contexto.Set<T>().Add(entity);
            _contexto.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            var entryEntity = _contexto.Set<T>().Attach(entity);
            entryEntity.State = EntityState.Modified;
            _contexto.SaveChanges();

            return entity;
        }

        public void Delete(T entity)
        {
            _contexto.Set<T>().Remove(entity);
            _contexto.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _contexto.Set<T>().FirstOrDefault(x => x.Id == id);
            _contexto.Set<T>().Remove(entity);
            _contexto.SaveChanges();
        }
    }
}
