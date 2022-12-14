namespace EducationPortal.Infrastructure.DB.DbModels
{
    public class DbUser : DbBaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public ICollection<DbSkill> Skills { get; set; }

        public List<DbUserSkill> UserSkills { get; set; }

        public ICollection<DbMaterial> Materials { get; set; }

        public ICollection<DbCourse> Courses { get; set; }

        public List<DbUserCourse> UserCourses { get; set; }
    }
}
