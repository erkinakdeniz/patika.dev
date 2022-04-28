using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PatikaModelOdevi.BookOperations
{
    public class GetByIDBookQueryValidator:AbstractValidator<GetByIDBookQuery>
    {
        public GetByIDBookQueryValidator()
        {
            RuleFor(command => command.id).NotEmpty().NotNull();
        }
    }
}
