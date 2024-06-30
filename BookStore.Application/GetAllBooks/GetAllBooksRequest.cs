using BookStore.Application.GetBookById;
using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.GetAllBooks
{
    public class GetAllBooksRequest : IRequest<List<Book>>
    {
        public int PageNumber { get; set; } = 1;
        public int ObjectsOnPage { get; set; } = 10;
    }
}
