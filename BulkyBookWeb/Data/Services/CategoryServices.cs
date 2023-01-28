using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data.Services
{
    public class CategoryServices : ICategoryServices
    {
        private readonly ApplicationDbContext _db;
        public CategoryServices(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task AddAsync(Category category)
        {
            await _db.categories.AddAsync(category);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var result = await _db.categories.FirstOrDefaultAsync(n => n.Id == id);

            _db.categories.Remove(result);
            await _db.SaveChangesAsync();


        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            IEnumerable<Category> result =  _db.categories;
            return result;
        }

        public async Task<Category> GetByIdAsync(int id)
        {
            var result = await _db.categories.FirstOrDefaultAsync(n => n.Id == id);
            return result;
        }

        public async  Task<Category> UpdateAsync(int id, Category newCategory)
        {
            _db.Update(newCategory);
            await _db.SaveChangesAsync();
            return newCategory;
        }
    }
}
