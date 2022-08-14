using EducationPortal.Domain.Repository;
using EducationPortal.Domain.Entities;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public List<User> Users { get; set; }
        private static string userPath = @"D:\work\users.json";
        private readonly StorageManager<User> _storage = new StorageManager<User>();

        public UserRepository()
        {
            Users = new List<User>();
        }

        public List<User> GetUser()
        {
            List<User> users = _storage.ExctractItemsFromStorage(userPath);
            if (users != null)
            {
                Users = users;
            }
            return Users;
        }

        public User? GetUserByName(string name)
        {
            return Users.FirstOrDefault(x => x.Name == name);
        }

        public void SetUser(User user)
        {
            Users.Add(user);
            _storage.AddItemToStorage(Users, userPath);
        }
    }
}
