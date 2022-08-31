namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserService
    {
        public bool Authenticate(string userName, string password, User user);

        public bool TryCreateUser(string name, string password);

        public User GetUserById(int id);
    }
}
