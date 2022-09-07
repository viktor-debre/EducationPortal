namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserInfoService
    {
        public User GetUserById(int id);

        public User GetUserByName(string name);
    }
}
