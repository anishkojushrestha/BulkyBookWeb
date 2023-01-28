using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data.Services
{
    //interface just a contract
    public interface ICategoryServices
    {
        //return type -    method name
        //using async
        Task<IEnumerable<Category>> GetAllAsync();
        Task<Category> GetByIdAsync(int id);
        Task AddAsync(Category category);
        //check actor exis and update actor
        Task<Category> UpdateAsync(int id, Category newCategory);
        Task DeleteAsync(int id);
    }
}
