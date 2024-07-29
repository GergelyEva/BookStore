using BookStore.Domain;

namespace BookStore.Data.Abstractions
{//the interface inherits the irepository of type book. <Book here instead of the T for template>
  public interface IBookRepository : IRepository<Book>
  {
  }
}
