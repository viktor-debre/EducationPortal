using EducationPortal.Domain.Entities;

namespace EducationPortal.Infrastructure.DB.DbModels
{
    internal static class MapDomainModels
    {
        public static User MapDbUserToUser(this DbUser user)
        {
            return new User
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };
        }

        public static DbUser MapUserToDbUser(this User user)
        {
            return new DbUser
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password
            };
        }
    }
}
