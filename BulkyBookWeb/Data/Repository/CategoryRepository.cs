using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data.Repository
{
    public class CategoryRepository : Repository<Category>, ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        
    }
}
