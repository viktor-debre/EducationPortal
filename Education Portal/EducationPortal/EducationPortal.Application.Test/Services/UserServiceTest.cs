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

        [Theory]
        [InlineData("vebro", "1")]
        [InlineData("vebro", "123456")]
        [InlineData("Viktor", "dimka")]
        public async Task AuthenticateWithNotExistingUser(string name, string password)
        {
            int id = await _userService.Authenticate(name, password);

            bool result = id == 0 ? true : false;

            Assert.True(result);
        }

        [Theory]
        [InlineData("Viktor", "bebra")]
        [InlineData("NewUser", "hello")]
        [InlineData("Dima", "dimka")]
        public async Task AuthenticateWithExistingUser(string name, string password)
        {
            int id = await _userService.Authenticate(name, password);

            bool result = id > 0 ? true : false;

            Assert.True(result);
        }
    }
}
