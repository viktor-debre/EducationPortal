namespace EducationPortal.Application.Services
{
    internal class UserInfoService : IUserInfoService
    {
        private readonly IRepository<User> _userRepository;

        public UserInfoService(IRepository<User> userSkillRepository)
        {
            _userRepository = userSkillRepository;
        }

        public async Task<User> GetUserById(int id)
        {
            return await _userRepository.FindById(id);
        }

        public async Task<User> GetUserByName(string name)
        {
            var users = await _userRepository.Find();
            return users.FirstOrDefault(x => x.Name == name);
        }
    }
}
