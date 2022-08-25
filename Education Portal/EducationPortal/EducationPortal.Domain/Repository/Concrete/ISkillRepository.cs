namespace EducationPortal.Domain.Repository
{
    public interface ISkillRepository
    {
        public List<Skill> GetSkill();

        public void SetSkill(Skill skill);

        public void UpdateSkill(int id, Skill updatedSkill);

        public void DeleteSkill(int id);

        public void Save();
    }
}