using EducationPortal.Infrastructure.DB.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.Infrastructure.DB
{
    internal class PortalContext : DbContext
    {
        public PortalContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<DbUser> Users { get; set; }

        public DbSet<>

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortalDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
                    .ToTable("users");

            modelBuilder.Entity<>
        }
    }
}
