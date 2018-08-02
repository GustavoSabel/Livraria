using Bookstore.Domain.Commands;
using Bookstore.Domain.Entities;
using Bookstore.Domain.Handlers;
using Bookstore.Domain.Repositories;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Bookstore.Test.Handlers
{
    public class BookHandlerTest
    {
        public BookHandlerTest()
        {

        }

        [Fact]
        public void Insert()
        {
            var repositoryMock = new Mock<IBookRepository>();
            repositoryMock.Setup(x => x.Insert(It.IsAny<Book>())).Returns((Book x) => x);

            var handler = new BookHandler(repositoryMock.Object);

            var idAuthor = Guid.NewGuid();
            var book = handler.Insert(new InsertBookCommand()
            {
                Title = "Title",
                Synopsis = "Synopsis",
                AuthorId = idAuthor
            });

            book.Title.ShouldBe("Title");
            book.Synopsis.ShouldBe("Synopsis");
            book.AuthorId.ShouldBe(idAuthor);
        }

        [Fact]
        public void Update()
        {
            var repositoryMock = new Mock<IBookRepository>();
            repositoryMock.Setup(x => x.Update(It.IsAny<Book>())).Returns((Book x) => x);

            var handler = new BookHandler(repositoryMock.Object);

            var idBook = Guid.NewGuid();
            var idAuthor = Guid.NewGuid();
            var book = handler.Update(new UpdateBookCommand()
            {
                Id = idBook,
                Title = "Title",
                Synopsis = "Synopsis",
                AuthorId = idAuthor
            });

            book.Id.ShouldBe(idBook);
            book.Title.ShouldBe("Title");
            book.Synopsis.ShouldBe("Synopsis");
            book.AuthorId.ShouldBe(idAuthor);
        }
    }
}
