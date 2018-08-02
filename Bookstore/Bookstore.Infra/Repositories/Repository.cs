using Bookstore.Domain.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bookstore.Infra.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        public T Get(Guid id)
        {
            using (var db = new BookstoreContext())
            {
                return db.Set<T>().FirstOrDefault(x => x.Id == id);
                //return db.Query<T>().FirstOrDefault(x => x.Id == id);
            }
        }

        public T Insert(T entity)
        {
            using (var db = new BookstoreContext())
            {
                db.Set<T>().Add(entity);
                db.SaveChanges();
                return entity;
            }
        }

        public T Update(T entity)
        {
            using (var db = new BookstoreContext())
            {
                var entryEntity = db.Entry(entity);
                entryEntity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();

                return entity;
            }
        }

        public void Delete(Guid id)
        {
            using (var db = new BookstoreContext())
            {
                var entity = db.Set<T>().FirstOrDefault(x => x.Id == id);
                db.Remove(entity);
                db.SaveChanges();
            }
        }
    }
}
