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
            var skills = _userSkillRepository.Find();
            List<UserSkill> userSkills = new List<UserSkill>();
            foreach (var skill in skills)
            {
                if (skill.UserId == user.Id)
                {
                    userSkills.Add(skill);
                }
            }

            return userSkills;
        }
    }
}
