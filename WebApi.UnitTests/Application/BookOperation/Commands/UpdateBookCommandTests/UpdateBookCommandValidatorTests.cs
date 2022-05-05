using FluentAssertions;
using PatikaModelOdevi.BookOperations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.BookOperation.Commands.UpdateBookCommandTests
{
   public class UpdateBookCommandValidatorTests:IClassFixture<CommonTestFixture>
    {
        [Theory]
        [InlineData("asd",0,0,1)]
        [InlineData("assds", 0, 0, 2)]
        public void WhenInvalidınputsAreGiven_Valitor_ShouldBeReturnErrors(string title, int pageCount, int genreId,int id)
        {
            UpdateBookCommand command = new UpdateBookCommand(null);
            command.Model = new UpdateBookCommand.UpdateBookModel() { ID = id, GenreId = genreId, PageCount = pageCount, PublishDate = DateTime.Now.Date.AddYears(-1), Title = title };
            UpdateBookCommandValidator validations = new UpdateBookCommandValidator();
            //Act
            var result = validations.Validate(command);
            //Assets
            result.Errors.Count.Should().BeGreaterThan(0);
        }
    }
}
