using EducationPortal.Application.Interfaces.Shared;
using System.Text;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        ConsoleAuthentication consoleAuthentication;
        private readonly IUserAuthentication _userAuthenticationService;
        private readonly IUserRegistration _userRegistration;

        public ConsoleApplication(IUserRegistration _userRegistration, IUserAuthentication _userAuthenticationService)
        {
            this.consoleAuthentication = new ConsoleAuthentication(_userAuthenticationService, _userRegistration);
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;

            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                consoleAuthentication.Authenticate();
            }
        }
    }
}
