using EducationPortal.Infrastructure.DB.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.Infrastructure.DB
{
    internal class PortalContext : DbContext
    {
        public DbSet<DbUser> Users;

        public PortalContext() : base()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortalDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
                    .ToTable("users");
        }
    }
}
