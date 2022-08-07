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
                Console.WriteLine("Registration. Input username and password. Type quit command to return to authtentication");
                string input = Console.ReadLine() ?? "";
                bool isValidInput = true;
                string[] registrationData = input.Split(" ");

                if(input == "quit")
                {
                    break;
                }
                if (registrationData.Length != 2)
                {
                    Console.WriteLine("Wrong command for name or password data.");
                    continue;
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
                        continue;
                    }
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong format for name or password data.");
                }
            }
        }
    }
}
