using Bookstore.Domain.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

        [Required]
        [MaxLength(100)]
        public string FirstName { get; private set; }

        [Required]
        [MaxLength(100)]
        public string LastName { get; private set; }
        
        [NotMapped]
        public string FullName => FirstName + " " + LastName;

        public DateTime? Birthdate { get; private set; }
    }
}
