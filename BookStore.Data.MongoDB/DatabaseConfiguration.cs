
using BookStore.Data.Abstractions;

namespace BookStore.Data.MongoDB
{
  public class DatabaseConfiguration : IDatabaseConfiguration
  {
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
  }
}
