using BookStore.Data.Abstractions;
using BookStore.Data.MongoDB;
using BookStore.Domain;
using BookStore.Repositories;

namespace BookStore.Tests
{
  public class BookRepositoryTests : IDisposable
  {
    private IDatabaseConfiguration databaseConfiguration;
    private IDatabase database;
    private IBookRepository bookRepository;

    public BookRepositoryTests()
    {
      databaseConfiguration= new DatabaseConfiguration { 
      ConnectionString= "mongodb+srv://user:user@cluster0.dputnqs.mongodb.net/",
      DatabaseName="BookStore"
      };
      database = new Database(databaseConfiguration);
      bookRepository = new BookRepository(database);
    }

    [Fact]
    public async Task ShouldGetBook()
    {
      //List<string> genres = new List<string>() { "comedy", "humor" };
      //Book newBook = new Book {
      //  Id = "6492b5d2751145c2f50afb47",
      //  Title = "Carte de bucate",
      //  YearOfPublication = new DateTime(),
      //  Genres = genres,
      //};

      //await this.bookRepository.InsertAsync(newBook, CancellationToken.None);

      var foundBook = await this.bookRepository.GetByIdAsync("64923fb060592343846ae1d2", CancellationToken.None);

      Assert.NotNull(foundBook);
    }

    public void Dispose()
    {
     //
    }
  }
}
