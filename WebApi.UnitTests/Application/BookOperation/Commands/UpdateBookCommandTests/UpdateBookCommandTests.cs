using AutoMapper;
using FluentAssertions;
using PatikaModelOdevi.BookOperations;
using PatikaModelOdevi.DBOperations;
using PatikaModelOdevi.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperation.Commands.UpdateBookCommandTests
{
   public class UpdateBookCommandTests:IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;
        
        private readonly IMapper _mapper;
        public UpdateBookCommandTests(CommonTestFixture testFixture)
        {
            _context = testFixture.Context;
            _mapper = testFixture.Mapper;
        }
        [Fact]
        public void WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn()
        {
            //arrange(Hazırlık)
            var currentbook = _context.Books.SingleOrDefault(x => x.ID == 1);
            var book = new Book() { Title = "Test_WhenAlreadyExistBookTitleIsGiven_InvalidOperationException_ShouldBeReturn", PageCount = 100, PublishDate = new DateTime(1990, 01, 10), GenreId = 1 };
            currentbook.GenreId = book.GenreId;
            currentbook.PageCount = book.PageCount;
            currentbook.PublishDate = book.PublishDate;
            currentbook.Title = book.Title;
            _context.Update(currentbook);
            _context.SaveChanges();
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Model = new UpdateBookCommand.UpdateBookModel() { ID= currentbook.ID};
            //act (Çalıştırma)  //assert(Doğrulama)
            FluentActions.Invoking(() => command.Handle())
                .Should().Throw<InvalidOperationException>().And.Message.Should().Be("Kitap Yok");
        }
    }
}
