using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly PortalContext _context;

        public BookRepository(PortalContext context)
        {
            _context = context;
        }

        public void DeleteBook(int id)
        {
            var book = _context.Materials.Find(id);
            if (book != null)
            {
                _context.Materials.Remove(book);
                Save();
            }
        }

        public BookMaterial? GetBookById(int id)
        {
            return (BookMaterial?)_context.Materials.Find(id).MapDbMaterialToMaterial();
        }

        public List<BookMaterial> GetBooks()
        {
            List<BookMaterial> books = new List<BookMaterial>();
            foreach (var book in _context.Materials)
            {
                if (book is DbBookMaterial)
                {
                    books.Add((BookMaterial)book.MapDbMaterialToMaterial());
                }
            }

            return books;
        }

        public void SetBook(BookMaterial material)
        {
            _context.Materials.Add(material.MapMaterialToDbMaterial());
            Save();
        }

        public void UpdateBook(string name, BookMaterial updatedMaterial)
        {
            DbBookMaterial book = (DbBookMaterial)_context.Materials.FirstOrDefault(x => x.Name == name);
            if (book != null)
            {
                _context.Update(book);
                book.Name = updatedMaterial.Name;
                book.Format = updatedMaterial.Format;
                book.Author = updatedMaterial.Author;
                book.NumberPages = updatedMaterial.NumberPages;
                book.PublicationDate = updatedMaterial.PublicationDate;
                Save();
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
