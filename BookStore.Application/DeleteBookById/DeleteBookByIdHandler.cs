using BookStore.Data.Abstractions;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DeleteBookById
{
    public class DeleteBookByIdHandler : IRequestHandler<DeleteBookByIdRequest, DeleteBookByIdResponse>
    {
        private readonly IBookRepository bookRepository;

        public DeleteBookByIdHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }

        public async Task<DeleteBookByIdResponse> Handle(DeleteBookByIdRequest request, CancellationToken cancellationToken)
        {
            string id = request.Id;
            var bookDeleted = await this.bookRepository.DeleteAsync(id, cancellationToken);
            return new DeleteBookByIdResponse { BookDeleted = bookDeleted };
        }
    }
}
