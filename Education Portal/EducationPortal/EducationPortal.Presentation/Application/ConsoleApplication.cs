using System.Text;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        private readonly ConsoleAuthentication _consoleAuthentication;
        private readonly ConsoleMaterialManager _materialManager;
        private readonly ConsoleCourseManager _courseManager;

        public ConsoleApplication(IUserRegistration userRegistration, IUserAuthentication userAuthenticationService, IMaterialManageService materialManageService, ICourseService courseService)
        {
            _consoleAuthentication = new ConsoleAuthentication(userAuthenticationService, userRegistration);
            _materialManager = new ConsoleMaterialManager(materialManageService);
            _courseManager = new ConsoleCourseManager(courseService, materialManageService);
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;

            _consoleAuthentication.Authenticate();
            Console.WriteLine("You successfully authorized.");

            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Type 'material' to edit materials or 'course' to edit course");
                string input = Console.ReadLine() ?? "";
                if (input == "material")
                {
                    _materialManager.EditMaterials();
                    continue;
                }

                if (input == "course")
                {
                    _courseManager.EditCources();
                    continue;
                }
                else
                {
                    Console.WriteLine("Unknown command.");
                    Thread.Sleep(500);
                    continue;
                }
            }
        }
    }
}
