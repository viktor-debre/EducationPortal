﻿using EducationPortal.Application.Interfaces.Shared;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleAuthentication
    {
        IUserAuthenticationService userAuthenticationService;
        ConsoleRegisterUser registerUser = new ConsoleRegisterUser();     

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
                    isValidInput = false;
                }
                if ( authenticationData[0] == "" || authenticationData[1] == "")
                {
                    isValidInput = false;
                }

                if (isValidInput)
                {
                    userAuthenticationService.Authenticate(authenticationData[0], authenticationData[1]);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong format for name or password data.");
                }
            }
            Console.Clear();
        }
    }
}
