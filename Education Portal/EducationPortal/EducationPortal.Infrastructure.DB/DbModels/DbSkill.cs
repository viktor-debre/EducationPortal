using EducationPortal.Infrastructure.DB.DbModels.Common;

namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbSkill : BaseEntity
    {
        public string Title { get; set; }

        public ICollection<DbUser> Users { get; set; }

        public List<DbUserSkill> UserSkills { get; set; }
    }
}
