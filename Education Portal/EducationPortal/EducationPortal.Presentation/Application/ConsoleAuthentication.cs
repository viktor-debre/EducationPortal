﻿namespace EducationPortal.Presentation.Application
{
    internal class ConsoleAuthentication
    {
        private readonly IUserAuthentication _userAuthenticationService;
        private readonly ConsoleRegisterUser _registerUser;
        private readonly InputHandler _inputHandler = new InputHandler();

        public ConsoleAuthentication(IUserAuthentication userAuthenticationServicer, IUserRegistration userRegistration)
        {
            _userAuthenticationService = userAuthenticationServicer;
            _registerUser = new ConsoleRegisterUser(userRegistration);
        }

        public void AuthenticationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MenuConstants.AUTH_MENU);

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        if (Authenticate())
                        {
                            return;
                        }

                        break;
                    case "2":
                        _registerUser.RegisterUser();
                        break;
                    default:
                        Console.WriteLine(MenuConstants.WRONG_COMMAND);
                        break;
                }
            }
        }

        public bool Authenticate()
        {
            string operation = "authorizing";
            string input;
            if (!_inputHandler.TryInputStringValue(out input, "username and password", operation))
            {
                return false;
            }

            bool isValidInput = true;
            string[] authenticationData = input.Split(" ");
            if (authenticationData.Length != 2)
            {
                Console.WriteLine("Wrong lenth for name or password data.");
                Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                return false;
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
                    Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                    return true;
                }

                Console.WriteLine("You entered not existing name or wrong password data.");
                Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
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
