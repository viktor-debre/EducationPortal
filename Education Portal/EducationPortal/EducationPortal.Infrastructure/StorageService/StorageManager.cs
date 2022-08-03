using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Infrastructure.FileService;
using EducationPortal.Infrastructure.Serialization;

namespace EducationPortal.Infrastructure.StorageService
{
    internal class StorageManager<T> : IRepository<T>
    {
        static string defaultPath = @"D:\work\result.json";
        JsonSerializer<T> jsonItems = new JsonSerializer<T>();
        FileManager fileManager = new FileManager();

        public void AddItemToStorage(List<T> item, string path)
        {
            path = defaultPath;
            string jsonString = jsonItems.SerializeItem(item);
            fileManager.WriteFile(path, jsonString);
        }

        public List<T> ExctractItemsFromStorage(string path)
        {
            path = defaultPath;
            string readed = fileManager.ReadFile(path);
            List<T> deserialized = jsonItems.DecerializeItem(readed);
            return deserialized;
        }

    }
}
