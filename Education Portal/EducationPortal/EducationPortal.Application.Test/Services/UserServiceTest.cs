using EducationPortal.Application.Interfaces.Shared;

namespace EducationPortal.Application.Test.Services
{
    public class UserServiceTest
    {
        private readonly IUserService _userService;

        public UserServiceTest(IUserService userService)
        {
            _userService = userService;
        }

        [Fact]
        public async Task AuthenticateWithNotExistingUser()
        {
            Assert.Equal(await _userService.Authenticate("vebro", "1"), 0);
        }
    }
}
