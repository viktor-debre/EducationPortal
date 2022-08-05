using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Application.Interfaces.Shared;

namespace EducationPortal.Application.Services
{
    public class UserAuthenticationService : IUserAuthentication
    {
        IUserCRUD _usersCRUD;

        public UserAuthenticationService(IUserCRUD userCRUD)
        {
            _usersCRUD = userCRUD;
        }

        public bool Authenticate(string userName, string password)
        {
            if (_usersCRUD.ReadUserFromStorage().FirstOrDefault(u => u.Name == userName).Name != userName)
            {
                return false;
            }
            else
            {

            }
        }
    }
}
