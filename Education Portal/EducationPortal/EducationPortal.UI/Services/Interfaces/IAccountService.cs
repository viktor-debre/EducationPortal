namespace EducationPortal.UI.Services.Interfaces
{
    public interface IAccountService
    {
        public UserView? AutherticateUserByName(string name, string password);
    }
}
