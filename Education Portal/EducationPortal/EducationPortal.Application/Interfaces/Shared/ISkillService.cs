namespace EducationPortal.Application.Interfaces.Shared
{
    public interface ISkillService
    {
        public List<Skill> GetSkills();

        public Skill? GetSkillByTitle(string title);

        public void SetSkill(Skill skill);

        public void UpdateSkill(Skill skill, Skill updatedSkill);

        public void DeleteSkill(string title);

        public Skill? GetSkillById(int id);
    }
}
