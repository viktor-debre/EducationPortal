using EducationPortal.Domain.Repository;
using EducationPortal.Infrastructure.FileService;
using EducationPortal.Infrastructure.Serialization;

namespace EducationPortal.Infrastructure.StorageService
{
    internal class StorageManager<T> : IRepository<T>
    {
        private readonly JsonSerializer<T> _jsonSerializer = new JsonSerializer<T>();
        private readonly FileManager _fileManager = new FileManager();

        public void Add(T item)
        {
            throw new NotImplementedException();
        }

        public void AddItemToStorage(List<T> item, string path)
        {
            string jsonString = _jsonSerializer.SerializeItem(item);
            _fileManager.WriteFile(path, jsonString);
        }

        public List<T> ExctractItemsFromStorage(string path)
        {
            string readed = _fileManager.ReadFile(path);
            List<T> deserialized = _jsonSerializer.DecerializeItem(readed);
            return deserialized;
        }

        public List<T> Find()
        {
            throw new NotImplementedException();
        }

        public T FindById(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void Update(T item)
        {
            throw new NotImplementedException();
        }
    }
}
