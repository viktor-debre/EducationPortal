namespace EducationPortal.UI.Services.Interfaces
{
    public interface ISkillEditService
    {
        public List<SkillView> GetSkills();

        public void SetSkill(SkillView skill);

        public void RemoveSkill(SkillView skill);

        public void UpdateSkill(SkillView skill);

        public SkillView GetByIdSkill(int id);
    }
}
