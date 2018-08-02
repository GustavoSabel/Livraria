using System;

namespace Bookstore.Domain.Commands
{
    public class UpdateBookCommand : InsertBookCommand
    {
        public Guid Id { get; set; }
    }
}
