using Bookstore.Domain.Commands;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Handlers;
using Bookstore.Domain.Queries;
using Bookstore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private IBookRepository _repository;
        private BookHandler _handler;

        public BookController(IBookRepository repository, BookHandler handler)
        {
            _repository = repository;
            _handler = handler;
        }
        
        [HttpGet]
        public IEnumerable<BookListQuery> Get()
        {
            return _repository.GetAll();
        }
        
        [HttpGet("{id}")]
        public Book Get(Guid id)
        {
            return _repository.Get(id);
        }

        [HttpPost()]
        public Book Post(InsertBookCommand command)
        {
            return _handler.Insert(command);
        }

        [HttpPut()]
        public Book Put(InsertBookCommand command)
        {
            return _handler.Insert(command);
        }
    }
}
