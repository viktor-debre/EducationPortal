using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class BookRepository : IBookRepository
    {
        public List<BookMaterial> Books { get; set; }
        private const string bookPath = @"D:\work\book.json";
        private readonly StorageManager<BookMaterial> _storage = new StorageManager<BookMaterial>();

        public BookRepository()
        {
            Books = new List<BookMaterial>();
        }

        public List<BookMaterial> GetBooks()
        {
            List<BookMaterial> materials = _storage.ExctractItemsFromStorage(bookPath);
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
            _storage.AddItemToStorage(Books, bookPath);
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
                _storage.AddItemToStorage(Books, bookPath);
                return true;
            }
            return false;
        }

    }
}
