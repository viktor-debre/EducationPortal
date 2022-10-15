using System.Text;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        private readonly AuthenticationManager _consoleAuthentication;
        private readonly MaterialManager _materialManager;
        private readonly CourseManager _courseManager;
        private readonly SkillManager _skillManager;
        private readonly UserManager _userManager;
        private readonly UserCoursesManager _userCoursesManager;

        public ConsoleApplication(IUserInfoService userSkillService,
                                  IUserService userService,
                                  IMaterialManageService materialManageService,
                                  ICourseService courseService,
                                  ISkillService skillService,
                                  IUserCourseService userCourseService)
        {
            _consoleAuthentication = new AuthenticationManager(userService);
            _materialManager = new MaterialManager(materialManageService);
            _courseManager = new CourseManager(courseService, materialManageService, skillService);
            _skillManager = new SkillManager(skillService);
            _userManager = new UserManager(userSkillService);
            _userCoursesManager = new UserCoursesManager(userCourseService, courseService, userSkillService);
        }

        public async Task Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            while (true)
            {
                Console.Clear();
                int userId = 1;
                userId = await _consoleAuthentication.AuthenticationMenu();
                await MainMenu(userId);
            }
        }

        private async Task MainMenu(int userId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MenuStrings.MAIN_MENU);
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "1":
                        await _materialManager.EditMaterials();
                        break;
                    case "2":
                        await _skillManager.EditSkills();
                        break;
                    case "3":
                        await _courseManager.EditCources();
                        break;
                    case "4":
                        await _userManager.UserInformation(userId);
                        break;
                    case "5":
                        await _userCoursesManager.PassingCoursesMenu(userId);
                        break;
                    case "6":
                        return;
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }
    }
}
