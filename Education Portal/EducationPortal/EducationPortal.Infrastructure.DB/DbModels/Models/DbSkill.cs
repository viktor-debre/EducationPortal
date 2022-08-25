using EducationPortal.Infrastructure.DB.DbModels.Common;

namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbSkill : DbBaseEntity
    {
        public string Title { get; set; }

        public ICollection<DbUser> Users { get; set; }

        public List<DbUserSkill> UserSkills { get; set; }

        public ICollection<DbCourse> Courses { get; set; }
    }
}
