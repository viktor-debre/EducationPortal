using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.UI.Models.Mapping;

namespace EducationPortal.UI.Services.Implementation
{
    internal class UserInformationService : IUserInformationService
    {
        private readonly IUserInfoService _userInfo;
        private readonly IMapper _mapper;

        public UserInformationService(IUserInfoService userInfo, IMapper mapper)
        {
            _userInfo = userInfo;
            _mapper = mapper;
        }

        public async Task<UserView> GetUserInfo(string name)
        {
            var user = await _userInfo.GetUserByName(name);
            return _mapper.MapUserToViewModel(user);
        }
    }
}
