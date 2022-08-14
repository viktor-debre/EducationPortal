namespace EducationPortal.Presentation.Application
{
    internal class ConsoleAuthentication
    {
        private IUserAuthentication _userAuthenticationService;
        private ConsoleRegisterUser _registerUser;

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
                string input = Console.ReadLine() ?? "";
                if (string.IsNullOrEmpty(input))
                {
                    Console.WriteLine("Inputed empty string try again.");
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
                        break;
                    }

                    Console.WriteLine("You entered not existing name or wrong password data.");
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
