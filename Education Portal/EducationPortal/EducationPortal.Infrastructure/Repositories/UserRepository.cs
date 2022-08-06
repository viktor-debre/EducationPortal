using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities;
using EducationPortal.Infrastructure.StorageService;

namespace EducationPortal.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User>? Users { get; set; }
        StorageManager<User> storage = new StorageManager<User>();

        public void ReadUserFromStorage()
        {
            string userPath = @"D:\work\users.json";
            Users = storage.ExctractItemsFromStorage(userPath);
        }

        public void SetUserInStorage(User user)
        {
            string userPath = @"D:\work\users.json";
            Users.Add(user);
            storage.AddItemToStorage(Users, userPath);
        }
    }
}
