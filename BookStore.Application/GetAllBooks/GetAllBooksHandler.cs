using BookStore.Data.Abstractions;
using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.GetAllBooks
{
    public class GetAllBooksHandler : IRequestHandler<GetAllBooksRequest, List<Book>>
    {
        private readonly IBookRepository bookRepository;

        public GetAllBooksHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<List<Book>> Handle(GetAllBooksRequest request, CancellationToken cancellationToken)
        {
            return await bookRepository.GetAllAsync(request.PageNumber, request.ObjectsOnPage, cancellationToken);
        }
    }

}
