using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BulkyBookWeb.Data
{
    public class ApplicationDbContext:IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions options): base(options) { 
        }
        public DbSet<Category> categories { get; set; }
        public DbSet<CoverType> coverTypes { get; set; }
        public DbSet<Product> products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
    }
}
