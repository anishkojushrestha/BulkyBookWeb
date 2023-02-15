using BulkyBookWeb.Data.Repository.IRepository;

namespace BulkyBookWeb.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db) 
        {
            _db = db;
            Category = new CategoryRepository(db);
            CoverType= new CoverTypeRepository(db);
            Product =   new ProductRepository(db);
            Company = new CompanyRepository(db);
        } 

        public ICategoryRepository Category { get; private set; }

        public ICoverTypeRepository CoverType { get; private set; }

        public IProductRepository Product { get; private set; }
        public ICompanyRepository Company { get; private set; }
    }
}
