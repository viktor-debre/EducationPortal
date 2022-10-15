namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserService
    {
        public Task<int> Authenticate(string userName, string password);

        public Task<bool> TryCreateUser(string name, string password);
    }
}
