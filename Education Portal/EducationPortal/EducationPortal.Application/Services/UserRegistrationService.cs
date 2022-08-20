using EducationPortal.Application.Commands;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Application.Services
{
    internal class UserRegistrationService : IUserRegistration
    {
        private readonly IUserRepository _userRepository;

        public UserRegistrationService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public bool TryCreateUser(string name, string password)
        {
            User user = new User()
            {
                Name = name,
                Password = password,
                Skills = new List<Skill>()
            };
            CreateUser createUser = new CreateUser(_userRepository);
            return createUser.TryCreateUser(user);
        }
    }
}
