namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal class DbUser : BaseEntity
    {
        public string Name { get; set; }

        public string Password { get; set; }

        public ICollection<DbSkill> Skills { get; set; }

        public List<DbUserSkill> UserSkills { get; set; }
    }
}
