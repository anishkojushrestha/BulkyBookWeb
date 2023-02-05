using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;

        public ProductRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        
    }
}
