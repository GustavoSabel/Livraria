using Bookstore.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bookstore.Domain.Entities
{
    public class Book : Entity
    {
        [MaxLength(100)]
        [Required]
        public string Title { get; private set; }

        [Column(TypeName = "TEXT")]
        public string Synopsis { get; private set; }

        [Required]
        public Guid AuthorId { get; private set; }
        public Author Author { get; private set; }

        public Book(string title, string synopsis, Guid authorId)
        {
            Title = title;
            Synopsis = synopsis;
            AuthorId = authorId;
        }
    }
}
