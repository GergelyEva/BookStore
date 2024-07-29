namespace BookStore.Data.Abstractions
{
    public interface IRepository<T>
    { //Task=async, <type of return>
      //(params, CancellationToken- to check if a cancellation has been requested)
        Task<string> InsertAsync(T item, CancellationToken cancellationToken);
        Task<bool> UpdateAsync(T item, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(string id, CancellationToken cancellationToken);
        Task<List<T>> GetAllAsync(int pageNumber, int objectsOnPage, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(string id, CancellationToken cancellationToken);
    }
}
