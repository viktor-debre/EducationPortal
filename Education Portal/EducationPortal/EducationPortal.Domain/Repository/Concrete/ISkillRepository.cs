namespace EducationPortal.Domain.Repository
{
    public interface ISkillRepository
    {
        public List<Skill> GetSkills();

        public void SetSkill(Skill skill);

        public void UpdateSkill(Skill skill);

        public void DeleteSkill(Skill skill);

        public void Save();
    }
}