using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class BookRepository : IBookRepository
    {
        private const string BookPath = @"D:\work\book.json";

        private readonly StorageManager<BookMaterial> _storage = new StorageManager<BookMaterial>();

        public BookRepository()
        {
            Books = new List<BookMaterial>();
        }

        public List<BookMaterial> Books { get; set; }

        public List<BookMaterial> GetBooks()
        {
            List<BookMaterial> materials = _storage.ExctractItemsFromStorage(BookPath);
            if (materials != null)
            {
                Books = materials;
            }

            return Books;
        }

        public BookMaterial? GetBookByName(string name)
        {
            return Books.FirstOrDefault(x => x.Name == name);
        }

        public void SetBook(BookMaterial material)
        {
            Books.Add(material);
            _storage.AddItemToStorage(Books, BookPath);
        }

        public void UpdateBook(string name, BookMaterial updatedMaterial)
        {
            if (DeleteBook(name))
            {
                SetBook(updatedMaterial);
            }
        }

        public bool DeleteBook(string name)
        {
            var material = GetBookByName(name);
            if (material != null)
            {
                Books.Remove(material);
                _storage.AddItemToStorage(Books, BookPath);
                return true;
            }

            return false;
        }

        public BookMaterial GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteBook(BookMaterial book)
        {
            throw new NotImplementedException();
        }

        public void Save()
        {
            throw new NotImplementedException();
        }
    }
}
