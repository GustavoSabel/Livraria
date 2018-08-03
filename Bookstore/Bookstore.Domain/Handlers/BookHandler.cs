using System;
using Bookstore.Domain.Commands;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;

namespace Bookstore.Domain.Handlers
{
    public class BookHandler
    {
        private readonly IBookRepository _repository;

        public BookHandler(IBookRepository repository)
        {
            _repository = repository;
        }

        public Book Insert(InsertBookCommand command)
        {
            return _repository.Insert(new Book(command.Title, command.Synopsis, command.AuthorId));
        }

        public Book Update(UpdateBookCommand command)
        {
            return _repository.Update(new Book(command.Title, command.Synopsis, command.AuthorId) { Id = command.Id });
        }

        public void Delete(Guid id)
        {
            _repository.Delete(id);
        }
    }
}
