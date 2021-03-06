﻿using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Infra;
using Bookstore.Infra.Repositories;
using Shouldly;
using System;
using System.Linq;
using Xunit;

namespace Bookstore.Test.Repositories
{
    public class AuthoRepositoryTest : RepositoryTest
    {
        private IAuthorRepository _repository;

        public AuthoRepositoryTest()
        {
            _repository = new AuthorRepository(_contexto);
            //new BookstoreContext().Database.EnsureDeleted();
            
        }

        [Fact]
        public void Insert()
        {
            var author = new Author("Eric J.", "Evans", new DateTime(1945, 7, 2));
            _repository.Insert(author);

            author = _repository.Get(author.Id);
            author.FirstName.ShouldBe("Eric J.");
            author.LastName.ShouldBe("Evans");
            author.Birthdate.ShouldBe(new DateTime(1945, 7, 2));
        }

        [Fact]
        public void Update()
        {
            var authorId = _repository.Insert(new Author("Eric", "Evans", new DateTime(1945, 7, 2))).Id;

            var _novoRepository = new AuthorRepository(CriarContexto());
            var authorUpdated = _novoRepository.Update(new Author("EricX", "EvansX", new DateTime(1950, 1, 1)) { Id = authorId });

            authorUpdated = _repository.Get(authorUpdated.Id);
            authorUpdated.FirstName.ShouldBe("EricX");
            authorUpdated.LastName.ShouldBe("EvansX");
            authorUpdated.Birthdate.ShouldBe(new DateTime(1950, 1, 1));
        }

        [Fact]
        public void Delete()
        {
            var author = new Author("Eric", "Evans", new DateTime(1945, 7, 2));
            _repository.Insert(author);

            _repository = new AuthorRepository(CriarContexto());
            _repository.Delete(author.Id);
            _repository.Get(author.Id).ShouldBeNull();
        }

        [Fact]
        public void GetAll()
        {
            var author = _repository.Insert(new Author("Gustavo", "Sabel", new DateTime(1991, 09, 23)));

            var authors = _repository.GetAll();
            authors.Count.ShouldBeGreaterThan(1);

            var authorListaQuery = authors.First(x => x.Id == author.Id);
            authorListaQuery.FirstName.ShouldBe("Gustavo");
            authorListaQuery.LastName.ShouldBe("Sabel");
            authorListaQuery.FullName.ShouldBe("Gustavo Sabel");
            authorListaQuery.Birthdate.ShouldBe(new DateTime(1991, 09, 23));
        }
    }
}
