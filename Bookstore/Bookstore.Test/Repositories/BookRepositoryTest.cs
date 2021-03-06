﻿using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Bookstore.Infra.Repositories;
using Shouldly;
using System.Linq;
using Xunit;

namespace Bookstore.Test.Repositories
{
    public class BookRepositoryTest : RepositoryTest
    {
        public const string BIG_TEXT = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris id diam luctus, fringilla nulla at, pretium arcu. Integer viverra luctus erat, eget lacinia lacus efficitur sit amet. Aliquam sit amet lorem hendrerit, tincidunt nulla at, posuere quam. Cras vitae blandit mi, et efficitur mi. Nunc convallis commodo dolor a bibendum. Donec augue purus, pellentesque nec sem id, tincidunt posuere nunc. Curabitur placerat, orci vitae faucibus condimentum, mauris ex venenatis justo, et semper ex ante sagittis turpis. Mauris pretium a nisi et molestie. Aenean nec dapibus nisl. Vivamus vel justo laoreet, viverra lacus nec, mattis nisl. Phasellus elementum ex sed sagittis varius. Aliquam erat volutpat. Proin tincidunt ornare sem sollicitudin tempus. Fusce sollicitudin leo quis justo vestibulum sollicitudin. Etiam suscipit convallis mauris, at molestie dui. Nullam tincidunt, ex ac aliquam suscipit, nibh quam vulputate risus, id lacinia ante diam id elit.";

        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private Author _authorDouglasAdams;

        public BookRepositoryTest()
        {
            _authorRepository = new AuthorRepository(_contexto);
            _bookRepository = new BookRepository(_contexto);

            _authorDouglasAdams = _authorRepository.Insert(new Author("Douglas", "Adams", null));
        }

        [Fact]
        public void Insert()
        {
            var book = _bookRepository.Insert(new Book("Guia do mochileiro das galaxias", BIG_TEXT, _authorDouglasAdams.Id));

            book = _bookRepository.Get(book.Id);
            book.Title.ShouldBe("Guia do mochileiro das galaxias");
            book.Synopsis.ShouldBe(BIG_TEXT);
            book.AuthorId.ShouldBe(_authorDouglasAdams.Id);
        }

        [Fact]
        public void Update()
        {
            var book = _bookRepository.Insert(new Book("Guia do mochileiro das galaxias", null, _authorDouglasAdams.Id));
            
            book = new BookRepository(CriarContexto()).Update(new Book("The Hitchhiker's Guide to the Galaxy", "Alguma coisa", _authorDouglasAdams.Id) { Id = book.Id } );

            book = _bookRepository.Get(book.Id);
            book.Title.ShouldBe("The Hitchhiker's Guide to the Galaxy");
            book.Synopsis.ShouldBe("Alguma coisa");
            book.AuthorId.ShouldBe(_authorDouglasAdams.Id);
        }

        [Fact]
        public void GetAll()
        {
            var book = _bookRepository.Insert(new Book("Guia do mochileiro das galaxias", "", _authorDouglasAdams.Id));

            var books = _bookRepository.GetAll();
            books.Count.ShouldBeGreaterThan(1);

            var bookQuery = books.Single(x => x.Id == book.Id);
            bookQuery.Title.ShouldBe("Guia do mochileiro das galaxias");
            bookQuery.AuthorId.ShouldBe(_authorDouglasAdams.Id);
            bookQuery.AuthorName.ShouldBe(_authorDouglasAdams.FullName);
        }

        [Fact]
        public void Delete()
        {
            var book = _bookRepository.Insert(new Book("Guia do mochileiro das galaxias", "", _authorDouglasAdams.Id));

            _bookRepository = new BookRepository(CriarContexto());
            _bookRepository.Delete(book.Id);

            _bookRepository.Get(book.Id).ShouldBeNull();
        }
    }
}
