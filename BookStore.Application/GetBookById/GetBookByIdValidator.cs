using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.GetBookById
{
    public class GetBookByIdValidator :AbstractValidator<GetBookByIdRequest>
    {
        public GetBookByIdValidator()
        {
            this.RuleFor(request => request.Id).NotEmpty();
        }
    }
}
