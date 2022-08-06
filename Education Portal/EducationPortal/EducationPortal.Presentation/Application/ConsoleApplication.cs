using System.Text;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        ConsoleAuthentication consoleAuthentication;

        public ConsoleApplication(ConsoleAuthentication consoleAuthentication)
        {
            this.consoleAuthentication = consoleAuthentication;
        }

        public void Run()
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.InputEncoding = Encoding.Unicode;
            while (true)
            {
                consoleAuthentication.Authenticate();
            }
        }
    }
}
