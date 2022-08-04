namespace EducationPortal.Presentation.Application
{
    internal class ConsoleApplication
    {
        public void Run()
        {
            ConsoleAuthentication consoleAuthentication = new ConsoleAuthentication();

            while (true)
            {
                consoleAuthentication.Authenticate();
            }
        }
    }
}
