using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DeleteBookById
{
    public class DeleteBookByIdValidator : AbstractValidator<DeleteBookByIdRequest>
    {
        public DeleteBookByIdValidator()
        {
            this.RuleFor(request => request.Id).NotEmpty();
        }
    }
}
