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

        public bool Authenticate(string userName, string password, ref int userId)
        {
            var userNameSpec = new SpecificationBase<User>(x => x.Name == userName);
            var existingUser = _userRepository.Find(userNameSpec).FirstOrDefault();
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
