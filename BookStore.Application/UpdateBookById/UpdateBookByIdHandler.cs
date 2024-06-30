using BookStore.Data.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UpdateBookById
{

    public class UpdateBookByIdHandler : IRequestHandler<UpdateBookByIdRequest, UpdateBookByIdResponse>
    {
        private readonly IBookRepository bookRepository;

        public UpdateBookByIdHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<UpdateBookByIdResponse> Handle(UpdateBookByIdRequest request, CancellationToken cancellationToken)
        {
            var book = request.Book;
            var updated = await this.bookRepository.UpdateAsync(book, cancellationToken);
            return new UpdateBookByIdResponse { BookUpdated = updated };
        }
    }
}
