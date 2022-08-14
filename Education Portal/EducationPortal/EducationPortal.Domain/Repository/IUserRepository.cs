using EducationPortal.Domain.Entities;

namespace EducationPortal.Domain.Repository
{
    public interface IUserRepository
    {
        public List<User> Users { get; }

        public List<User> GetUser();

        public User? GetUserByName(string name);

        public void SetUser(User user);
    }
}
