using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Driver;

namespace BookStore.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly IMongoCollection<Book> books;

        public BookRepository(IDatabase database)
        {
            books = database.GetCollection<IMongoCollection<Book>, Book>("Books");
        }

        // Filters to get the book by id, deletes with DeleteAsync the found book
        // Return true if the book was deleted
        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            var result = await this.books.DeleteOneAsync(filter, cancellationToken);
            return result.DeletedCount > 0;
        }

        // The requested number of objects will show up, thus making the viewing easier
        // Also, the page didn't load with too many objects 
        public async Task<List<Book>> GetAllAsync(int pageNumber, int objectsOnPage, CancellationToken cancellationToken)
        {
            return await books.Find(book => true)
                               .Skip((pageNumber - 1) * objectsOnPage)
                               .Limit(objectsOnPage)
                               .ToListAsync(cancellationToken);
        }

        // Get book by ID
        public async Task<Book> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            var book = await this.books.Find(filter).FirstOrDefaultAsync(cancellationToken);

            if (book == null)
            {
                Console.Write($"Book not found with ID: {id}");
            }
            return book;
        }

        public async Task<string> InsertAsync(Book item, CancellationToken cancellationToken)
        {
            await this.books.InsertOneAsync(item, new InsertOneOptions(), cancellationToken);
            return item.Id;
        }

        public async Task<bool> UpdateAsync(Book item, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, item.Id);
            var updateResult = await this.books.ReplaceOneAsync(filter, item, new ReplaceOptions(), cancellationToken);
            return updateResult.ModifiedCount > 0;
        }
    }
}
