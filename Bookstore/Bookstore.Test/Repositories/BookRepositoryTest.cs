using Bookstore.Domain.Entities;
using Bookstore.Domain.Repositories;
using Shouldly;
using Xunit;

namespace Bookstore.Test.Repositories
{
    public class BookRepositoryTest
    {
        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;
        private Author _authorDouglasAdams;

        public BookRepositoryTest()
        {
            //_repository = new BookRepository();

            _authorDouglasAdams = _authorRepository.Insert(new Author("Douglas", "Adams", null));
        }

        [Fact]
        public void Insert()
        {
            var book = _bookRepository.Insert(new Book("Guia do mochileiro das galaxias", _authorDouglasAdams.Id));

            book = _bookRepository.Get(book.Id);
            book.Title.ShouldBe("Guia do mochileiro das galaxias");
            book.AuthorId.ShouldBe(_authorDouglasAdams.Id);
        }

        [Fact]
        public void Update()
        {
            var book = _bookRepository.Insert(new Book("Guia do mochileiro das galaxias", _authorDouglasAdams.Id));

            _bookRepository.Update(new Book("The Hitchhiker's Guide to the Galaxy", _authorDouglasAdams.Id) { Id = book.Id });

            book = _bookRepository.Get(book.Id);
            book.Title.ShouldBe("The Hitchhiker's Guide to the Galaxy");
            book.AuthorId.ShouldBe(_authorDouglasAdams.Id);
        }

        [Fact]
        public void GetAll()
        {
            var book = _bookRepository.Insert(new Book("Guia do mochileiro das galaxias", _authorDouglasAdams.Id));

            var books = _bookRepository.GetAll();
            books.Count.ShouldBe(1);
            books[0].Title.ShouldBe("Guia do mochileiro das galaxias");
            books[0].AuthorId.ShouldBe(_authorDouglasAdams.Id);
            books[0].AuthorName.ShouldBe(_authorDouglasAdams.FullName);
        }
    }
}
