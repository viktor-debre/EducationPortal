namespace EducationPortal.Application.Services
{
    internal class UserAuthenticationService : IUserAuthentication
    {
        private readonly IRepository<User> _usersRepository;

        public UserAuthenticationService(IRepository<User> usersRepository)
        {
            _usersRepository = usersRepository;
        }

        public bool Authenticate(string userName, string password)
        {
            List<User> users = _usersRepository.Find();
            var checkUser = users.FirstOrDefault(x => x.Name == userName);
            if (checkUser == null)
            {
                return false;
            }

            int idOfUser = checkUser.Id;
            User existingUser = _usersRepository.FindById(idOfUser);
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
