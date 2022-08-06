using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Domain.Entities;

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
            _usersRepository.ReadUserFromStorage();
            List<User>? users = _usersRepository.Users;
            User? existingUser = users.FirstOrDefault(u => u.Name == userName);
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
