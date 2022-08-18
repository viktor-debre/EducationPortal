namespace EducationPortal.Domain.Repository
{
    public interface IUserRepository
    {
        public List<User> GetUsers();

        public User? GetUserById(int id);

        public void SetUser(User user);

        public void UpdateUser(User user);

        public void DeleteUser(User user);

        public void Save();
    }
}
