using Microsoft.Extensions.Configuration;

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

        public DbSet<DbUserCourse> UserCourses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var builder = new ConfigurationBuilder();
            string workingDirectory = Environment.CurrentDirectory;
            string projectDirectory = Directory.GetParent(workingDirectory).Parent.Parent.FullName;
            builder.AddJsonFile(projectDirectory + "/appsettings.json");
            var config = builder.Build();
            string connectionString = config.GetConnectionString("SqlServerConnectionStrings");

            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=PortalDb");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DbUser>()
                    .ToTable("Users");

            modelBuilder.Entity<DbMaterial>()
                    .ToTable("Materials");

            modelBuilder.Entity<DbBookMaterial>();
            modelBuilder.Entity<DbVideoMaterial>();
            modelBuilder.Entity<DbArticleMaterial>();

            modelBuilder.Entity<DbCourse>()
                    .ToTable("Courses");

            modelBuilder.Entity<DbSkill>()
                    .ToTable("Skills");

            modelBuilder.Entity<DbCourse>()
              .HasMany(u => u.Skills)
              .WithMany(m => m.Courses)
              .UsingEntity(um => um.ToTable("CourseSkill"));

            modelBuilder.Entity<DbCourse>()
              .HasMany(u => u.Materials)
              .WithMany(m => m.Courses)
              .UsingEntity(um => um.ToTable("CourseMaterials"));

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
                    userSkills.Property(us => us.Level);
                    userSkills.HasKey(us => new { us.UserId, us.SkillId });
                });

            modelBuilder.Entity<DbUser>()
            .HasMany(u => u.Courses)
            .WithMany(c => c.Users)
            .UsingEntity<DbUserCourse>(
                userCourses => userCourses
                    .HasOne(uc => uc.Course)
                    .WithMany(c => c.UserCourses)
                    .HasForeignKey(uc => uc.CourseId),
                userCourses => userCourses
                    .HasOne(uc => uc.User)
                    .WithMany(u => u.UserCourses)
                    .HasForeignKey(uc => uc.UserId),
                userCourses =>
                {
                    userCourses.Property(uc => uc.Status);
                    userCourses.Property(uc => uc.PassPercent);
                    userCourses.HasKey(uc => new { uc.UserId, uc.CourseId});
                });
        }
    }
}
