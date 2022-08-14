namespace EducationPortal.Presentation.Application
{
    internal class ConsoleAuthentication
    {
        private const int WrongCommandDelay = 1500;
        private readonly IUserAuthentication _userAuthenticationService;
        private readonly ConsoleRegisterUser _registerUser;
        private readonly InputHandler _inputHandler = new InputHandler();

        public ConsoleAuthentication(IUserAuthentication userAuthenticationServicer, IUserRegistration userRegistration)
        {
            _userAuthenticationService = userAuthenticationServicer;
            _registerUser = new ConsoleRegisterUser(userRegistration);
        }

        public void Authenticate()
        {
            while (true)
            {
                Console.WriteLine("Authorize to continue work: Input username and password. If you are not registred input command reg");
                string operation = "authorizing";
                string input;
                if (!_inputHandler.TryInputStringValue(out input, "username and password", operation))
                {
                    continue;
                }

                if (input.Equals("reg"))
                {
                    _registerUser.RegisterUser();
                    continue;
                }

                bool isValidInput = true;
                string[] authenticationData = input.Split(" ");
                if (authenticationData.Length != 2)
                {
                    Console.WriteLine("Wrong command for name or password data.");
                    Thread.Sleep(WrongCommandDelay);
                    continue;
                }

                if (authenticationData[0] == "" || authenticationData[1] == "")
                {
                    isValidInput = false;
                }

                if (isValidInput)
                {
                    if (_userAuthenticationService.Authenticate(authenticationData[0], authenticationData[1]))
                    {
                        Console.Clear();
                        Console.WriteLine("You successfully authorized.");
                        Thread.Sleep(WrongCommandDelay);
                        return;
                    }

                    Console.WriteLine("You entered not existing name or wrong password data.");
                    Thread.Sleep(WrongCommandDelay);
                    continue;
                }
                else
                {
                    Console.WriteLine("Wrong name or password data.");
                }
            }
        }
    }
}
