using Api_Practice.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_Practice.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Category> Categories { get; set; }
    }
}
