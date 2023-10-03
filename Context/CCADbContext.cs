using CCA_BE.Models;
using Microsoft.EntityFrameworkCore;
using CCA_BE.Controllers;

namespace CCA_BE.Context
{
    public class CCADbContext : DbContext
    {
        public CCADbContext(DbContextOptions<CCADbContext> options):base(options) { 

        }

        public DbSet<User> Users { get; set; }
        public DbSet<AnualExcelModel> Evs { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<AnualExcelModel>().ToTable("evs");

            
        }
    }
}
