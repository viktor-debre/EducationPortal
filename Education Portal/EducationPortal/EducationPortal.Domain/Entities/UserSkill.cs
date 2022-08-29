namespace EducationPortal.Domain.Entities
{
    public class UserSkill : BaseEntity
    {
        public int UserId { get; set; }

        public int SkillId { get; set; }

        public int Level { get; set; }
    }
}
