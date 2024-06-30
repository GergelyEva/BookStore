using BookStore.Application.DeleteBookById;
using BookStore.Application.GetAllBooks;
using BookStore.Application.GetBookById;
using BookStore.Application.GetWeatherForecast;
using BookStore.Application.InsertBook;
using BookStore.Application.UpdateBookById;
using BookStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;
        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        //Get book by id
        [HttpGet("{id}", Name = "GetBookById")]
        public async Task<IActionResult> Get(string id, CancellationToken token)
        {
            var response = await this.mediator.Send(new GetBookByIdRequest { Id = id }, token);
            return this.Ok(response);
        }

        //Insert book by id
        [HttpPost(Name = "InsertBook")]
        public async Task<IActionResult> Insert([FromBody] InsertBookRequest request, CancellationToken token)
        {
            var response = await mediator.Send(request, token);
            return CreatedAtRoute("GetBookById", new { id = response.BookId }, response.Book);
        }

        // Update book
        [HttpPut("{id}", Name = "UpdateBookById")]
        public async Task<IActionResult> UpdateAsync(string id, [FromBody] Book book, CancellationToken token)
        {
            var bookExists = await mediator.Send(new GetBookByIdRequest { Id = id }, token);

            if (bookExists.Book == null)
            {
                Console.Write($"Book not found with ID: {id}");
            }

            var foundBook = bookExists.Book;
            foundBook.Title = book.Title;
            foundBook.AuthorId = book.AuthorId;
            foundBook.Genres = book.Genres;
            foundBook.YearOfPublication = book.YearOfPublication;
            foundBook.PublisherId = book.PublisherId;

            var response = await mediator.Send(new UpdateBookByIdRequest { Book = foundBook }, token);

            return NoContent();
        }

        //Delete by Id
        [HttpDelete("{id}", Name = "DeleteBookById")]
        public async Task<IActionResult> DeleteAsync(string id, CancellationToken token)
        {
            var response = await mediator.Send(new DeleteBookByIdRequest { Id = id }, token);
            return this.Ok(response);
        }

        //GetAllBooks
        //modified the parameters, added pagenumber and pagesize, because it took too long to load
        [HttpGet(Name = "GetAllBooks")]
        public async Task<IActionResult> GetAllAsync([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 10, CancellationToken token = default)
        {
          
             var response = await mediator.Send(new GetAllBooksRequest { PageNumber = pageNumber, ObjectsOnPage = pageSize }, token);
             return Ok(response);
         
        }

    }
}
