namespace EducationPortal.Domain.Repository
{
    public interface IRepository<T>
    {
        public void AddItemToStorage(List<T> item, string path);

        public List<T> ExctractItemsFromStorage(string path);
    }
}
