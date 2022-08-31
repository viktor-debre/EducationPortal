namespace EducationPortal.Application.Services
{
    internal class UserSkillsService : IUserSkillService
    {
        private readonly IUserSkillRepository _userSkillRepository;

        public UserSkillsService(IUserSkillRepository userSkillRepository)
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
