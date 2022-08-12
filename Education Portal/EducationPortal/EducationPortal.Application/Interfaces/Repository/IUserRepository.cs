namespace EducationPortal.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        public List<User> Users { get; }

        public List<User> GetUser();

        public User? GetUserByName(string name);

        public void SetUser(User user);
    }
}
