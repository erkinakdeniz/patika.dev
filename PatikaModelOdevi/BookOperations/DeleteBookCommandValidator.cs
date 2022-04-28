using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.BookOperations
{
    public class DeleteBookCommandValidator:AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookCommandValidator()
        {
            RuleFor(command => command.id).NotEmpty().NotNull();
        }
    }
}
