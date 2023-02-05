using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data.Repository
{
    public class CoverTypeRepository : Repository<CoverType>, ICoverTypeRepository
    {
        private ApplicationDbContext _db;

        public CoverTypeRepository(ApplicationDbContext db): base(db)
        {
            _db = db;
        }

        
    }
}
