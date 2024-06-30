using BookStore.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.InsertBook
{
    public class InsertBookResponse
    {
        public string? BookId { get; set; }
        public Book? Book { get; set; } 

        public InsertBookResponse()
        {
            Book = new Book();  
        }
    }
}
