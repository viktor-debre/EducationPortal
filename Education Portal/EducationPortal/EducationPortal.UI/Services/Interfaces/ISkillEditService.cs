namespace EducationPortal.UI.Services.Interfaces
{
    public interface ISkillEditService
    {
        public Task<List<SkillView>> GetSkills();

        public Task SetSkill(SkillView skill);

        public Task RemoveSkill(SkillView skill);

        public Task UpdateSkill(SkillView skill);

        public Task<SkillView> GetByIdSkill(int id);
    }
}
