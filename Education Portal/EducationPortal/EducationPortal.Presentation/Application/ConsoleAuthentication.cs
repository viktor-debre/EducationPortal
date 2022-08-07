namespace EducationPortal.Presentation.Application
{
    internal class ConsoleAuthentication
    {
        private IUserAuthentication _userAuthenticationService;
        private ConsoleRegisterUser registerUser;     

        public ConsoleAuthentication(IUserAuthentication userAuthenticationServicer, IUserRegistration userRegistration)
        {
            this._userAuthenticationService = userAuthenticationServicer;
            this.registerUser = new ConsoleRegisterUser(userRegistration);
        }

        public void Authenticate()
        {
            while (true)
            {
                Console.WriteLine("Authorize to continue work: Input username and password. If you are not registred input command reg");
                string input = Console.ReadLine() ?? "";
                if (input == "")
                {
                    Console.WriteLine("Inputed empty string try again.");
                    continue;
                }
                if (input.Equals("reg"))
                {
                    registerUser.RegisterUser();
                    continue;
                }
                bool isValidInput = true;
                string[] authenticationData = input.Split(" ");

                if(authenticationData.Length != 2)
                {
                    Console.WriteLine("Wrong command for name or password data.");
                    continue;
                }
                if ( authenticationData[0] == "" || authenticationData[1] == "")
                {
                    isValidInput = false;
                }

                if (isValidInput)
                {
                    if(_userAuthenticationService.Authenticate(authenticationData[0], authenticationData[1]))
                    {
                        Console.Clear();
                        break;
                    }
                    Console.WriteLine("Wrong name or password data.");
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
