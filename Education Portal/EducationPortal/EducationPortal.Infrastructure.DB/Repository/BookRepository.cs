using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class BookRepository : IBookRepository, IDisposable
    {
        private readonly PortalContext _context;

        public BookRepository(PortalContext context)
        {
            _context = context;
        }

        public void DeleteBook(BookMaterial book)
        {
            _context.Materials.Remove(book.MapMaterialToDbMaterial());
            Save();
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
            _context.Add(material.MapMaterialToDbMaterial());
            Save();
        }

        public void UpdateBook(string name, BookMaterial updatedMaterial)
        {
            _context.Entry(updatedMaterial.MapMaterialToDbMaterial()).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
