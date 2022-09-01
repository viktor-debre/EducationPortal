namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserService
    {
        public bool Authenticate(string userName, string password, int userId);

        public bool TryCreateUser(string name, string password);
    }
}
