using EducationPortal.Domain.Entities;

namespace EducationPortal.Presentation.Application
{
    internal class UserManager
    {
        private readonly IUserService _userService;

        public UserManager(IUserService userService)
        {
            _userService = userService;
        }

        public void UserInformation(User user)
        {
            Console.Clear();
            OutputUserInformation(user);

            while (true)
            {
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void OutputUserInformation(User user)
        {
            Console.WriteLine($"User name: {user.Name}\n" +
                $"password: {user.Password}");
            OutputUserMaterials(user);
            OutputUserSkills(user);
        }

        private void OutputUserMaterials(User user)
        {
            if (user.Materials == null)
            {
                return;
            }

            foreach (var material in user.Materials)
            {
                Console.WriteLine($"User passed materials: {material}");
            }
        }

        private void OutputUserSkills(User user)
        {
            if (user.Skills == null)
            {
                return;
            }

            foreach (var skill in user.Skills)
            {
                Console.WriteLine($"User skills: {skill}");
            }
        }
    }
}
