using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.InsertBook
{
    public class InsertBookValidator : AbstractValidator<InsertBookRequest>
    {
        public InsertBookValidator()
        {
            RuleFor(request => request.Book).NotNull();
            RuleFor(request => request.Book.Title).NotEmpty();
            RuleFor(request => request.Book.AuthorId).NotEmpty();
            RuleFor(request => request.Book.PublisherId).NotEmpty();
            RuleFor(request => request.Book.YearOfPublication).NotEqual(default(DateTime));
            RuleForEach(request => request.Book.Genres).NotEmpty();
        }
    }
}
