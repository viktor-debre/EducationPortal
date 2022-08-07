using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Application.Interfaces.Shared;

namespace EducationPortal.Application.Services
{
    internal class UserAuthenticationService : IUserAuthentication
    {
        IUserRepository _usersRepository;

        public UserAuthenticationService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool Authenticate(string userName, string password)
        {
            List<User> users = _usersRepository.ReadUserFromStorage();
            User? existingUser = users.FirstOrDefault(u => u.Name == userName, null);
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
                return true;
            }
        }
    }
}
