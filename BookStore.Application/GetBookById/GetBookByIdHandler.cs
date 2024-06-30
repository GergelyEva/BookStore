using BookStore.Data.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.GetBookById
{
    public class GetBookByIdHandler :IRequestHandler<GetBookByIdRequest,GetBookByIdResponse>
    {
        private readonly IBookRepository bookRepository;

        public GetBookByIdHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<GetBookByIdResponse> Handle(GetBookByIdRequest request, CancellationToken cancellationToken)
        {
            string id = request.Id;
            var book = await this.bookRepository.GetByIdAsync(id, cancellationToken);
            return new GetBookByIdResponse { Book = book }; 
        }

    
    }
}
