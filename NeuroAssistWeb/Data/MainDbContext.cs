using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NeuroAssist.Models;

namespace NeuroAssist.Data
{
    #nullable disable
    public class MainDbContext : DbContext
    {

        protected MainDbContext(DbContextOptions options) : base(options)
        {
        }

        public MainDbContext(DbContextOptions<MainDbContext> options)
            : base(options)
        {
            //if(!Database.GetAppliedMigrations().Any())
            //{
            //    Database.Migrate();
            //}
        }

        public DbSet<BrainScan> BrainScans { get; set; }
        public DbSet<ProjectScan> ProjectScans { get; set; }

    }
}