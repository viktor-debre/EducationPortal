namespace EducationPortal.Infrastructure.FileService
{
    internal class FileManager
    {
        public void WriteFile(string pathToFile, string content)
        {
            File.WriteAllText(pathToFile, content);
        }

        public string ReadFile(string pathToFile)
        {
            return File.ReadAllText(pathToFile);
        }
    }
}
