using System.Text;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        ConsoleAuthentication _consoleAuthentication;
        ConsoleMaterialManager _materialManager;
        ConsoleCourseManager _courseManager;

        public ConsoleApplication(IUserRegistration _userRegistration, IUserAuthentication _userAuthenticationService, 
                IMaterialManageService _materialManageService, ICourseService courseService)
        {
            _consoleAuthentication = new ConsoleAuthentication(_userAuthenticationService, _userRegistration);
            _materialManager = new ConsoleMaterialManager(_materialManageService);
            _courseManager = new ConsoleCourseManager(courseService, _materialManageService);
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
