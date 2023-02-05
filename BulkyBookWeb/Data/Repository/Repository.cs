using BulkyBookWeb.Data.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;

namespace BulkyBookWeb.Data.Repository
{
    public class Repository<T> : IRepository<T> where T : class, IBaseRepository,new()
    {
        private readonly ApplicationDbContext _db;
        public Repository(ApplicationDbContext _db)
        {
            this._db = _db;
        }

        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _db.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Deleted;
            await _db.SaveChangesAsync();
        }

        public IEnumerable<T> GetAll()
        {
            IQueryable<T> query = _db.Set<T>();
            return query.ToList();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            //IQueryable<T> query = _db.Set<T>();
            //return await query.ToListAsync();
            IQueryable<T> result = _db.Set<T>();
            return result;
        }

        public async Task<T> GetByIdAsync(int id)
        {
            var data = await _db.Set<T>().FirstOrDefaultAsync(n => n.Id == id);
            return data;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _db.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _db.SaveChangesAsync();
        }
    }
}
