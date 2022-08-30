namespace EducationPortal.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IUserSkillRepository _userSkillRepository;

        public UserService(IUserSkillRepository userSkillRepository)
        {
            _userSkillRepository = userSkillRepository;
        }

        public List<UserSkill> GetUserSkillsInfo(User user)
        {
            var skills = _userSkillRepository.Find().FindAll(s => s.UserId == user.Id);

            return skills;
        }
    }
}
