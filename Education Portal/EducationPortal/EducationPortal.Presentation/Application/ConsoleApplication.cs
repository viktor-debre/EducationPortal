using System.Text;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        private readonly ConsoleAuthentication _consoleAuthentication;
        private readonly ConsoleMaterialManager _materialManager;
        private readonly ConsoleCourseManager _courseManager;
        private readonly ConsoleSkillManager _skillManager;

        public ConsoleApplication(IUserRegistration userRegistration,
                                  IUserAuthentication userAuthenticationService,
                                  IMaterialManageService materialManageService,
                                  ICourseService courseService,
                                  ISkillService skillService)
        {
            _consoleAuthentication = new ConsoleAuthentication(userAuthenticationService, userRegistration);
            _materialManager = new ConsoleMaterialManager(materialManageService);
            _courseManager = new ConsoleCourseManager(courseService, materialManageService, skillService);
            _skillManager = new ConsoleSkillManager(skillService);
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;

            while (true)
            {
                Console.Clear();
                _consoleAuthentication.AuthenticationMenu();
                MainMenu();
            }
        }

        private void MainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(MenuConstants.MAIN_MENU);
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
                        return;
                        break;
                    default:
                        Console.WriteLine(MenuConstants.WRONG_COMMAND);
                        Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }
    }
}
