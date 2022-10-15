namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserInfoService
    {
        public Task<User> GetUserById(int id);

        public Task<User> GetUserByName(string name);
    }
}
