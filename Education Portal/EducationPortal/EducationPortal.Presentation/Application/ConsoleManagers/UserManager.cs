using EducationPortal.Domain.Entities;

namespace EducationPortal.Presentation.Application
{
    internal class UserManager
    {
        private readonly IUserInfoService _userInfoService;

        public UserManager(IUserInfoService userSkillService)
        {
            _userInfoService = userSkillService;
        }

        public void UserInformation(int userId)
        {
            Console.Clear();
            OutputUserInformation(userId);
            Console.WriteLine(MenuStrings.USER_ACCONT_MENU);
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

        private void OutputUserInformation(int userId)
        {
            var user = _userInfoService.GetUserById(userId);

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

            Console.WriteLine("User passed materials: ");
            foreach (var material in user.Materials)
            {
                Console.WriteLine($"Material name: {material.Name}");
            }
        }

        private void OutputUserSkills(User user)
        {
            if (user.Skills == null)
            {
                return;
            }

            Console.WriteLine("User skills:");
            foreach (var userSkill in user.UserSkills)
            {
                var skill = user.Skills.Find(s => s.Id == userSkill.SkillId);
                Console.WriteLine($"Skills: {skill.Title} with level: {userSkill.Level}");
            }
        }
    }
}
