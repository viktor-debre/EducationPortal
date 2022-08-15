using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.DB.DbModels.Common;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class UserRepository : IUserRepository
    {
        private PortalContext _context;

        public UserRepository(PortalContext context)
        {
            _context = context;
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user.MapUserToDbUser());
            Save();
        }

        public List<User> GetUsers()
        {
            List<User> users = new List<User>();
            foreach (var user in _context.Users)
            {
                users.Add(user.MapDbUserToUser());
            }

            return users;
        }

        public User? GetUserById(int id)
        {
            return _context.Users.Find(id).MapDbUserToUser();
        }

        public void SetUser(User user)
        {
            _context.Add(user.MapUserToDbUser());
            Save();
        }

        public void UpdateUser(User user)
        {
            _context.Entry(user.MapUserToDbUser()).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
