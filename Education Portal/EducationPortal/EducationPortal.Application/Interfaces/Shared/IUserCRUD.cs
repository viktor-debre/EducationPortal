using EducationPortal.Domain.Entities;

namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IUserCRUD
    {
        public List<User> ReadUserFromStorage();

        public void SetUserInStorage(User user);
    }
}
