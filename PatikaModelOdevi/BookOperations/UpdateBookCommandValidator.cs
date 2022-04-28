using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.BookOperations
{
    public class UpdateBookCommandValidator:AbstractValidator<UpdateBookCommand>
    {
        public UpdateBookCommandValidator()
        {
            RuleFor(command => command.Model.GenreId).NotEmpty().NotNull().GreaterThan(0).LessThan(4);
            RuleFor(command => command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(DateTime.Now.Date);
            RuleFor(command => command.Model.Title).MinimumLength(4).NotEmpty();
        }
    }
}
