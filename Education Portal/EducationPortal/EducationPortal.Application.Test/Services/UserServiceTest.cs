using EducationPortal.Application.Interfaces.Shared;

namespace EducationPortal.Application.Test.Services
{
    public class UserServiceTest : IClassFixture<Startup>
    {
        private readonly IUserService _userService;

        public UserServiceTest(IUserService userService)
        {
            _userService = userService;
        }

        [Fact]
        public async Task AuthenticateWithNotExistingUser()
        {
            Assert.Equal(0, await _userService.Authenticate("vebro", "1"));
        }
    }
}
