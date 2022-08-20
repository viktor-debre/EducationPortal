namespace EducationPortal.Application.Interfaces.Shared
{
    public interface ISkillService
    {
        public List<Skill> GetSkills();

        public void SetSkill(Skill skill);

        public void UpdateSkill(string title, Skill updatedSkill);

        public void DeleteSkill(string title);
    }
}
