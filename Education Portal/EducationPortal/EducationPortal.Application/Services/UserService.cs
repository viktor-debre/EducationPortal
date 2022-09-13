using EducationPortal.Application.Commands.CreateEntity;

namespace EducationPortal.Application.Services
{
    internal class UserService : IUserService
    {
        private readonly IRepository<User> _userRepository;

        public UserService(IRepository<User> usersRepository)
        {
            _userRepository = usersRepository;
        }

        public bool Authenticate(string userName, string password, ref int userId)
        {
            List<User> users = _userRepository.Find();
            var existingUser = users.FirstOrDefault(x => x.Name == userName);
            if (existingUser == null)
            {
                return false;
            }

            if (existingUser.Password != password)
            {
                return false;
            }
            else
            {
                userId = existingUser.Id;

                return true;
            }
        }

        public bool TryCreateUser(string name, string password)
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
            return createUser.TryCreateUser(user);
        }
    }
}
