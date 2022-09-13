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

        public void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            while (true)
            {
                Console.Clear();
                int userId = 1;
                _consoleAuthentication.AuthenticationMenu(ref userId);
                MainMenu(userId);
            }
        }

        private void MainMenu(int userId)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MenuStrings.MAIN_MENU);
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "1":
                        _materialManager.EditMaterials();
                        break;
                    case "2":
                        _skillManager.EditSkills();
                        break;
                    case "3":
                        _courseManager.EditCources();
                        break;
                    case "4":
                        _userManager.UserInformation(userId);
                        break;
                    case "5":
                        _userCoursesManager.PassingCoursesMenu(userId);
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
