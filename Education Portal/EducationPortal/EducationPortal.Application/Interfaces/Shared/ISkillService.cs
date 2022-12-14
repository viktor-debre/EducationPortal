namespace EducationPortal.Application.Interfaces.Shared
{
    public interface ISkillService
    {
        public Task<List<Skill>> GetSkills();

        public Task<Skill?> GetSkillByTitle(string title);

        public Task SetSkill(Skill skill);

        public Task UpdateSkill(Skill skill);

        public Task DeleteSkill(Skill skill);

        public Task<Skill?> GetSkillById(int id);
    }
}
