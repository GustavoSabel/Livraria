using System;

namespace Bookstore.Domain.Base
{
    public class Entity
    {
        public Guid Id { get; set; }

        public Entity()
        {
            //Id = Guid.NewGuid();
        }
    }
}
