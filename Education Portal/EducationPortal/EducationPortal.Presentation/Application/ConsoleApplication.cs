﻿using System.Text;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        private readonly AuthenticationManager _consoleAuthentication;
        private readonly MaterialManager _materialManager;
        private readonly CourseManager _courseManager;
        private readonly SkillManager _skillManager;

        public ConsoleApplication(IUserRegistration userRegistration,
                                  IUserAuthentication userAuthenticationService,
                                  IMaterialManageService materialManageService,
                                  ICourseService courseService,
                                  ISkillService skillService)
        {
            _consoleAuthentication = new AuthenticationManager(userAuthenticationService, userRegistration);
            _materialManager = new MaterialManager(materialManageService);
            _courseManager = new CourseManager(courseService, materialManageService, skillService);
            _skillManager = new SkillManager(skillService);
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
