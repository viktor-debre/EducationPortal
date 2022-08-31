using EducationPortal.Domain.Entities;

namespace EducationPortal.Presentation.Application
{
    internal class AuthenticationManager
    {
        private readonly IUserService _userAuthenticationService;
        private readonly RegisterUserManager _registerUser;
        private readonly InputHandler _inputHandler = new InputHandler();

        public AuthenticationManager(IUserService userAuthenticationService)
        {
            _userAuthenticationService = userAuthenticationService;
            _registerUser = new RegisterUserManager(userAuthenticationService);
        }

        public void AuthenticationMenu(User user)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MenuStrings.AUTH_MENU);

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (Authenticate(user))
                        {
                            return;
                        }

                        break;
                    case "2":
                        _registerUser.RegisterUser();
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        public bool Authenticate(User user)
        {
            string input;
            if (!_inputHandler.TryInputStringValue(out input, "username and password", Operation.AUTHORIZING, EntityName.USER))
            {
                return false;
            }

            bool isValidInput = true;
            string[] authenticationData = input.Split(" ");
            if (authenticationData.Length != 2)
            {
                Console.WriteLine("Wrong lenth for name or password data.");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return false;
            }

            if (authenticationData[0] == "" || authenticationData[1] == "")
            {
                isValidInput = false;
            }

            if (isValidInput)
            {
                if (_userAuthenticationService.Authenticate(authenticationData[0], authenticationData[1], user))
                {
                    Console.Clear();
                    Console.WriteLine("You successfully authorized.");
                    Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                    return true;
                }

                Console.WriteLine("You entered not existing name or wrong password data.");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return false;
            }
            else
            {
                Console.WriteLine("Wrong name or password data.");
                return false;
            }
        }
    }
}
