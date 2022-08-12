namespace EducationPortal.Application.Services
{
    internal class UserAuthenticationService : IUserAuthentication
    {
        private readonly IUserRepository _usersRepository;

        public UserAuthenticationService(IUserRepository usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool Authenticate(string userName, string password)
        {
            List<User> users = _usersRepository.GetUser();
            User? existingUser = _usersRepository.GetUserByName(userName);
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
