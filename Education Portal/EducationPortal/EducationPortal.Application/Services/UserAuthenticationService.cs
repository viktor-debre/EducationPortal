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
            List<User> users = _usersRepository.GetUsers();
            var checkUser = users.FirstOrDefault(x => x.Name == userName);
            if (checkUser == null)
            {
                return false;
            }

            int idOfUser = checkUser.Id;
            User existingUser = _usersRepository.GetUserById(idOfUser);
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
