using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.DeleteBookById
{
    public class DeleteBookByIdRequest : IRequest<DeleteBookByIdResponse>
    {
        public string Id { get; set; }
    }
}
