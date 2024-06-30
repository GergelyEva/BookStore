namespace BookStore.Data.Abstractions
{
  public interface IDatabase
  {
    TCollection? GetCollection<TCollection, TItem>(string Name) where TCollection : class;
  }
}
