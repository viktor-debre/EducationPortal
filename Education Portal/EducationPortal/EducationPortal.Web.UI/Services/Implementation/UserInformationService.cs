using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Web.UI.Models.Mapping;

namespace EducationPortal.Web.UI.Services.Implementation
{
    internal class UserInformationService : IUserInformationService
    {
        private readonly IUserInfoService _userInfo;
        private readonly IMapper _mapper;

        public UserInformationService(IUserInfoService userInfo, IMapper _mapper)
        {
            _userInfo = userInfo;
        }

        public UserView GetUserInfo(string name)
        {
            var user = _userInfo.GetUserByName(name);
            return new UserView()
            {
                Name = user.Name,
                Password = user.Password
            };
        }
    }
}
