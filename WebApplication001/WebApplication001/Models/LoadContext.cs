using Microsoft.EntityFrameworkCore;

namespace WebApplication001.Models
{
    public class LoadContext : DbContext
    {
        public LoadContext(DbContextOptions<LoadContext> options)
                : base(options)
        {
        }

        public DbSet<Load> Load { get; set; }
    }
}