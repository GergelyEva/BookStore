using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UpdateBookById
{
    public class UpdateBookByIdRequest : IRequest<UpdateBookByIdResponse>
    {
        public Book Book { get; set; }
    }
}
