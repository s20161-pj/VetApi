using Microsoft.EntityFrameworkCore;
using VetApp.DataAccess.Models;

namespace VetApp.Api.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Vet> Vets { get; set; }
        public DbSet<Clinic> Clinics { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<VeterinaryVisit> VeterinaryVisit { get; set; }
        public DbSet<VeterinaryVisit> VeterinaryVisits { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public MainContext()
        {

        }
        public MainContext(DbContextOptions options) : base(options)
        {
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("DataSource=dbo.VetApp.db");
        }
      
    }
}
