namespace EducationPortal.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserSkill> GetUserSkillsInfo(User user)
        {
            var skills = new List<UserSkill>();
            foreach (var skill in user.Skills)
            {
            }

            return skills;
        }
    }
}
