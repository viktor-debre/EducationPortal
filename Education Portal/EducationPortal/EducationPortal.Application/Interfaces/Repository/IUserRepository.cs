using EducationPortal.Domain.Entities;

namespace EducationPortal.Application.Interfaces.Repository
{
    public interface IUserRepository
    {
        public List<User> Users { get; }

        public List<User> ReadUserFromStorage();

        public void SetUserInStorage(User user);
    }
}
