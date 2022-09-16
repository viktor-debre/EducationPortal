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

        public async Task<int> AuthenticationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MenuStrings.AUTH_MENU);

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        int userId = await Authenticate();
                        if (userId != 0)
                        {
                            return userId;
                        }

                        break;
                    case "2":
                        await _registerUser.RegisterUser();
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        public async Task<int> Authenticate()
        {
            string input;
            if (!_inputHandler.TryInputStringValue(out input, "username and password", Operation.AUTHORIZING, EntityName.USER))
            {
                return 0;
            }

            bool isValidInput = true;
            string[] authenticationData = input.Split(" ");
            if (authenticationData.Length != 2)
            {
                Console.WriteLine("Wrong lenth for name or password data.");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return 0;
            }

            if (authenticationData[0] == "" || authenticationData[1] == "")
            {
                isValidInput = false;
            }

            if (isValidInput)
            {
                var authenticateUserId = await _userAuthenticationService.Authenticate(authenticationData[0], authenticationData[1]);
                if (authenticateUserId != 0)
                {
                    Console.Clear();
                    Console.WriteLine("You successfully authorized.");
                    Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                    return authenticateUserId;
                }

                Console.WriteLine("You entered not existing name or wrong password data.");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return 0;
            }
            else
            {
                Console.WriteLine("Wrong name or password data.");
                return 0;
            }
        }
    }
}
