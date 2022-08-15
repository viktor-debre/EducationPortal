using EducationPortal.Infrastructure.DB.DbModels;
using Microsoft.EntityFrameworkCore;

namespace EducationPortal.Infrastructure.DB
{
    internal class PortalContext : DbContext
    {
        public DbSet<DbUser> Users;

        public PortalContext(DbContextOptions<PortalContext> options) : base(options)
        {
        }
    }
}
