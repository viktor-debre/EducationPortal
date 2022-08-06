using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities;
using EducationPortal.Infrastructure.StorageService;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public List<User> Users { get; set; }
        private readonly StorageManager<User> _storage = new StorageManager<User>();

        public UserRepository()
        {
            Users = new List<User>();
        }

        public List<User> ReadUserFromStorage()
        {
            string userPath = @"D:\work\users.json";
            List<User> users = _storage.ExctractItemsFromStorage(userPath);
            if (users != null)
            {
                Users = users;
            }
            return Users;
        }

        public void SetUserInStorage(User user)
        {
            string userPath = @"D:\work\users.json";
            Users.Add(user);
            _storage.AddItemToStorage(Users, userPath);
        }
    }
}
