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
            if (string.IsNullOrWhiteSpace(title))
                throw new Exception("Título é um campo obrigatório");

            if (authorId == Guid.Empty)
                throw new Exception("Autor é um campo obrigatório");

            Title = title;
            Synopsis = synopsis;
            AuthorId = authorId;
        }
    }
}
