using Microsoft.EntityFrameworkCore;
using VetApp.Api.Models;

namespace VetApp.Api.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Vet> Vet { get; set; }
        public MainContext()
        {

        }
        public MainContext(DbContextOptions options) : base(options)
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(connectionString: "DataSource=dbo.VetApp.db");
        }
      
    }
}
