using BulkyBookWeb.Data.Repository.IRepository;
using BulkyBookWeb.Models;

namespace BulkyBookWeb.Data.Repository
{
    public class CompanyRepository:Repository<Company>, ICompanyRepository
    {
        private ApplicationDbContext _db;

        public CompanyRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

    }
}
