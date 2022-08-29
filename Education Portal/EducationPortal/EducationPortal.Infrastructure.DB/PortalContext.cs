namespace EducationPortal.Infrastructure.DB
{
    internal class PortalContext : DbContext
    {
        public PortalContext() : base()
        {
            Database.EnsureCreated();
        }

        public DbSet<DbUser> Users { get; set; }

        public DbSet<DbMaterial> Materials { get; set; }

        public DbSet<DbCourse> Courses { get; set; }

        public DbSet<DbSkill> Skills { get; set; }

        public DbSet<DbUserSkill> UserSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortalDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
                    .ToTable("Users");

            modelBuilder.Entity<DbMaterial>()
                    .ToTable("Materials");

            modelBuilder.Entity<DbCourse>()
                    .ToTable("Courses");

            modelBuilder.Entity<DbSkill>()
                    .ToTable("Skills");

            modelBuilder.Entity<DbBookMaterial>();
            modelBuilder.Entity<DbVideoMaterial>();
            modelBuilder.Entity<DbArticleMaterial>();

            modelBuilder.Entity<DbUser>()
                .HasMany(u => u.Materials)
                .WithMany(m => m.Users)
                .UsingEntity(um => um.ToTable("UserMaterials"));

            modelBuilder.Entity<DbUser>()
            .HasMany(u => u.Skills)
            .WithMany(s => s.Users)
            .UsingEntity<DbUserSkill>(
                userSkills => userSkills
                    .HasOne(us => us.Skill)
                    .WithMany(s => s.UserSkills)
                    .HasForeignKey(us => us.SkillId),
                userSkills => userSkills
                    .HasOne(us => us.User)
                    .WithMany(u => u.UserSkills)
                    .HasForeignKey(us => us.UserId),
                userSkills =>
                {
                    userSkills.Property(pt => pt.Level);
                    userSkills.HasKey(t => new { t.UserId, t.SkillId});
                });
        }
    }
}
