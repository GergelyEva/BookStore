using BookStore.Domain;

namespace BookStore.Data.Abstractions
{
  public interface IBookRepository : IRepository<Book>
  {
  }
}
