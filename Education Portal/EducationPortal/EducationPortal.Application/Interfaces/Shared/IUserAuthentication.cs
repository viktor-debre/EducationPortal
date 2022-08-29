namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserAuthentication
    {
        public bool Authenticate(string userName, string password);

        public bool TryCreateUser(string name, string password);
    }
}
