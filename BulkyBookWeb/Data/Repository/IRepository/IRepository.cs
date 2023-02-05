using System.Linq.Expressions;

namespace BulkyBookWeb.Data.Repository.IRepository
{
    public interface IRepository<T> where T: class, IBaseRepository, new()
    {
        Task<IEnumerable<T>> GetAllAsync();

        IEnumerable<T> GetAll();
        Task AddAsync(T entity);


        Task<T> GetByIdAsync(int id);
        Task UpdateAsync(int id, T entity);

        Task DeleteAsync(int id);
    }
}
