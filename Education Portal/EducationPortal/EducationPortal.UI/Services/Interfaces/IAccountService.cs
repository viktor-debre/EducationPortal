namespace EducationPortal.UI.Services.Interfaces
{
    public interface IAccountService
    {
        public UserView? AuthenticateUserByName(string name, string password);

        public void RegisterUser(string name, string password);
    }
}
