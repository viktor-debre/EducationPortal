namespace EducationPortal.UI.Services.Interfaces
{
    public interface IUserInformationService
    {
        public Task<UserView> GetUserInfo(string name);
    }
}
