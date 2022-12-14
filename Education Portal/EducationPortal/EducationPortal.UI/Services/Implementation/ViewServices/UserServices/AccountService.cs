using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.UI.Models.Mapping;

namespace EducationPortal.UI.Services.Implementation
{
    public class AccountService : IAccountService
    {
        private readonly IUserInfoService _userInfo;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AccountService(IUserInfoService userInfo, IMapper mapper, IUserService userService)
        {
            _userInfo = userInfo;
            _mapper = mapper;
            _userService = userService;
        }

        public async Task<UserView?> AuthenticateUserByName(string name, string password)
        {
            UserView userToAuth;
            var user = await _userInfo.GetUserByName(name);
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

        public async Task RegisterUser(string name, string password)
        {
            await _userService.TryCreateUser(name, password);
        }
    }
}
