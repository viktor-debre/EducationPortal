using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.UI.Models.Mapping;

namespace EducationPortal.UI.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUserInfoService _userInfo;
        private readonly IMapper _mapper;

        public AccountService(IUserInfoService userInfo, IMapper mapper)
        {
            _userInfo = userInfo;
            _mapper = mapper;
        }

        public UserView? AuthenticateUserByName(string name, string password)
        {
            UserView userToAuth;
            var user = _userInfo.GetUserByName(name);
            if (user != null && user.Password == password)
            {
                userToAuth = _mapper.MapUserToViewModel(user);
            }
            else
            {
                userToAuth = null;
            }

            return userToAuth;
        }
    }
}
