namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserSkillService
    {
        public List<UserSkill> GetUserSkillsInfo(User user);
    }
}
