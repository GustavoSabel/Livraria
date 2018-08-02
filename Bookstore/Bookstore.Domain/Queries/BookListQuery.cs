using System;

namespace Bookstore.Domain.Queries
{
    public class BookListQuery
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid AuthorId { get; set; }
        public string AuthorName { get; set; }
    }
}
