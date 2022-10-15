using EducationPortal.Application.Commands.CreateEntity;
using EducationPortal.Domain.Helpers.Specification;

namespace EducationPortal.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> usersRepository)
        {
            _userRepository = usersRepository;
        }

        public async Task<int> Authenticate(string userName, string password)
        {
            var userNameSpec = new SpecificationBase<User>(x => x.Name == userName);
            var existingUsers = await _userRepository.Find(userNameSpec);
            var existingUser = existingUsers.FirstOrDefault();
            if (existingUser == null)
            {
                return 0;
            }

            if (existingUser.Password != password)
            {
                return 0;
            }
            else
            {
                return existingUser.Id;
            }
        }

        public async Task<bool> TryCreateUser(string name, string password)
        {
            User user = new User()
            {
                Name = name,
                Password = password,
                Skills = new List<Skill>(),
                Materials = new List<Material>(),
                Courses = new List<Course>(),
                UserCourses = new List<UserCourse>(),
                UserSkills = new List<UserSkill>()
            };
            CreateUser createUser = new CreateUser(_userRepository);
            var result = await createUser.TryCreateUser(user);
            return result;
        }
    }
}
