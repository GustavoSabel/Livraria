using System;

namespace Bookstore.Domain.Commands
{
    public class InsertBookCommand
    {
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public Guid AuthorId { get; set; }
    }
}
