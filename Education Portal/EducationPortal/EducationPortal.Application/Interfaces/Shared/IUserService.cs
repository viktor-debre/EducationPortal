namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserService
    {
        public List<UserSkill> GetUserSkillsInfo(User user);
    }
}
