using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Domain.Entities;

namespace EducationPortal.Infrastructure.StorageService
{
    public class FileContext : IUserCRUD
    {
        public List<User>? Users { get; set; }
        StorageManager<User> storage = new StorageManager<User>();

        public List<User> ReadUserFromStorage()
        {
            string userPath = @"D:\work\users.json";
            Users = storage.ExctractItemsFromStorage(userPath);
            return Users;
        }

        public void SetUserInStorage(User user)
        {
            string userPath = @"D:\work\users.json";
            Users.Add(user);
            storage.AddItemToStorage(Users, userPath);
        }
    }
}
