namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserService
    {
        public bool Authenticate(string userName, string password, ref int userId);

        public bool TryCreateUser(string name, string password);
    }
}
