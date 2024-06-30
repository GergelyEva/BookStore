using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.GetAllBooks
{
    public class GetAllBooksResponse
    {
        public List<Book> Books { get; set; } = new List<Book>();
    }
}
