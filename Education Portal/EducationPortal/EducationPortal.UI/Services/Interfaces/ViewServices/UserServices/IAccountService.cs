namespace EducationPortal.UI.Services.Interfaces
{
    public interface IAccountService
    {
        public Task<UserView?> AuthenticateUserByName(string name, string password);

        public Task RegisterUser(string name, string password);
    }
}
