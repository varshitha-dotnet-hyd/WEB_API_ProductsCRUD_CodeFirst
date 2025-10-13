using Microsoft.EntityFrameworkCore;
using WEB_API_ProductsCRUD_CodeFirst.Models;

namespace WEB_API_ProductsCRUD_CodeFirst.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Ornament> Ornaments { get; set; }
    }
}
