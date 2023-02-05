using BulkyBookWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { 
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<CoverType> coverTypes { get; set; }
        public DbSet<Product> products { get; set; }
    }
}
