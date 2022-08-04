using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Application.Services;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleRegisterUser
    {
        IUserCRUD userService = new UserService();

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
                    userService.CreateUser(registrationData[0], registrationData[1]);
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
