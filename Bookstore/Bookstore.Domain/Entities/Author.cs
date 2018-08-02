using Bookstore.Domain.Base;
using System;

namespace Bookstore.Domain.Entities
{
    public class Author : Entity
    {
        public Author(string firstName, string lastName, DateTime? birthdate)
        {
            FirstName = firstName;
            LastName = lastName;
            Birthdate = birthdate;
        }

        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string FullName => FirstName + " " + LastName;
        public DateTime? Birthdate { get; private set; }
    }
}
