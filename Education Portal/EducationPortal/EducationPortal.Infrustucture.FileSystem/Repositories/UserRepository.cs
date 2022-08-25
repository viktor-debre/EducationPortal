﻿using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private static string UserPath = @"D:\work\users.json";

        private readonly StorageManager<User> _storage = new StorageManager<User>();

        public UserRepository()
        {
            Users = new List<User>();
        }

        public List<User> Users { get; set; }

        public void DeleteUser(User user)
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

        public User? GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByName(string name)
        {
            return Users.FirstOrDefault(x => x.Name == name);
        }

        public List<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public void SetUser(User user)
        {
            Users.Add(user);
            _storage.AddItemToStorage(Users, UserPath);
        }

        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
    }
}
