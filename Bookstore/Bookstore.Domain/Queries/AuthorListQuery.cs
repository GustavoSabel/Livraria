using System;

namespace Bookstore.Domain.Queries
{
    public class AuthorListQuery
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName => FirstName + " " + LastName;
        public DateTime? Birthdate { get; set; }
    }
}
