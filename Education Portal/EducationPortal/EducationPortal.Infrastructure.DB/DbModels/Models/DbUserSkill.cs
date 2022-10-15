namespace EducationPortal.Infrastructure.DB.DbModels
{
    public class DbUserSkill
    {
        public int Level { get; set; }

        public int UserId { get; set; }

        public DbUser User { get; set; }

        public int SkillId { get; set; }

        public DbSkill Skill { get; set; }
    }
}
