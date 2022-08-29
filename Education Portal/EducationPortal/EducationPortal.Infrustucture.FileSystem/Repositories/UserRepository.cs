using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class UserRepository : IRepository<User>
    {
        private static string UserPath = @"D:\work\users.json";

        private readonly StorageManager<User> _storage = new StorageManager<User>();

        public UserRepository()
        {
            Users = new List<User>();
        }

        public List<User> Users { get; set; }

        public void Delete(User user)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUser()
        {
            List<User> users = _storage.ExctractItemsFromStorage(UserPath);
            if (users != null)
            {
                Users = users;
            }

            return Users;
        }

        public User? FindById(int id)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByName(string name)
        {
            return Users.FirstOrDefault(x => x.Name == name);
        }

        public List<User> Find()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void Add(User user)
        {
            Users.Add(user);
            _storage.AddItemToStorage(Users, UserPath);
        }

        public void Update(User user)
        {
            throw new NotImplementedException();
        }

        public void Remove(User entity)
        {
            throw new NotImplementedException();
        }
    }
}
