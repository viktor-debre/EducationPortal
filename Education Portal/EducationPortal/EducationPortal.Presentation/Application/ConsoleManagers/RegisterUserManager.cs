namespace EducationPortal.Presentation.Application
{
    internal class RegisterUserManager
    {
        private readonly IUserAuthentication _userRegistration;

        public RegisterUserManager(IUserAuthentication userRegistration)
        {
            _userRegistration = userRegistration;
        }

        public void RegisterUser()
        {
            while (true)
            {
                Console.WriteLine(MenuStrings.REGISTRATION_MENU);

                string input = Console.ReadLine() ?? "";
                bool isValidInput = true;
                string[] registrationData = input.Split(" ");

                if (input == "quit")
                {
                    break;
                }

                if (registrationData.Length != 2)
                {
                    Console.WriteLine("Wrong command for name or password data.");
                    Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                    continue;
                }

                if (string.IsNullOrEmpty(registrationData[0]) || string.IsNullOrEmpty(registrationData[1]))
                {
                    isValidInput = false;
                }

                if (isValidInput)
                {
                    if (!_userRegistration.TryCreateUser(registrationData[0], registrationData[1]))
                    {
                        Console.WriteLine("User with this name already exists.");
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        continue;
                    }

                    break;
                }
                else
                {
                    Console.WriteLine("Wrong format for name or password data.");
                    Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                }
            }
        }
    }
}
