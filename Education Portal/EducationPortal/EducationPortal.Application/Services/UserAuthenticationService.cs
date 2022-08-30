using EducationPortal.Application.Commands;

namespace EducationPortal.Application.Services
{
    internal class UserAuthenticationService : IUserAuthentication
    {
        private readonly IRepository<User> _userRepository;

        public UserAuthenticationService(IRepository<User> usersRepository)
        {
            _userRepository = usersRepository;
        }

        public bool Authenticate(string userName, string password, User user)
        {
            List<User> users = _userRepository.Find();
            var checkUser = users.FirstOrDefault(x => x.Name == userName);
            if (checkUser == null)
            {
                return false;
            }

            int idOfUser = checkUser.Id;
            User existingUser = _userRepository.FindById(idOfUser);
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
                user.Id = existingUser.Id;
                user.Name = existingUser.Name;
                user.Skills = existingUser.Skills;
                user.Materials = existingUser.Materials;
                user.Password = password;
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
                Materials = new List<Material>()
            };
            CreateUser createUser = new CreateUser(_userRepository);
            return createUser.TryCreateUser(user);
        }
    }
}
