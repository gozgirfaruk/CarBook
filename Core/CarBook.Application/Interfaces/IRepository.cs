namespace CarBook.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsyc(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
