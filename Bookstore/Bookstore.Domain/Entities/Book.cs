using Bookstore.Domain.Base;
using System;

namespace Bookstore.Domain.Entities
{
    public class Book : Entity
    {
        public const int TITLE_MAX_LENGH = 100;

        public string Title { get; private set; }
        public string Abstract { get; private set; }
        public Guid AuthorId { get; private set; }

        public Book(string title, Guid authorId)
        {
            Title = title;
            AuthorId = authorId;
        }
    }
}
