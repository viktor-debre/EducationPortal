using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Application.Interfaces.Shared;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleRegisterUser
    {
        private readonly IUserRegistration _userRegistration;

        public ConsoleRegisterUser(IUserRegistration userRegistration)
        {
            _userRegistration = userRegistration;
        }

        public void RegisterUser()
        {
            while (true)
            {
                Console.WriteLine("Registration. Input username and password");
                string input = Console.ReadLine() ?? "";
                bool isValidInput = true;
                string[] registrationData = input.Split(" ");

                if (registrationData.Length != 2)
                {
                    isValidInput = false;
                }
                if (registrationData[0] == "" || registrationData[1] == "")
                {
                    isValidInput = false;
                }

                if (isValidInput)
                {
                    if(!_userRegistration.TryCreateUser(registrationData[0], registrationData[1]))
                    {
                        Console.WriteLine("Wrong format for name or password data.");
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("Wrong format for name or password data.");
                }
            }
        }
    }
}
