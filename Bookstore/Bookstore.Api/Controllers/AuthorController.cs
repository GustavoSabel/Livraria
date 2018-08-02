using Bookstore.Domain.Entities;
using Bookstore.Domain.Queries;
using Bookstore.Domain.Repositories;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Bookstore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private IAuthorRepository _repository;

        public AuthorController(IAuthorRepository repository)
        {
            _repository = repository;
        }
        
        [HttpGet]
        public IEnumerable<AuthorListQuery> Get()
        {
            return _repository.GetAll();
        }
        
        [HttpGet("{id}")]
        public Author Get(Guid id)
        {
            return _repository.Get(id);
        }
    }
}
