using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly PortalContext _context;
        private readonly MapToDbModels _mapper;

        public BookRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapToDbModels(context);
        }

        public void DeleteBook(BookMaterial material)
        {
            _context.Materials.Remove(_mapper.MapToDbMaterial(material));
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
            _context.Materials.Add(_mapper.MapToDbMaterial(material));
            Save();
        }

        public void UpdateBook(BookMaterial material)
        {
            _context.Entry(_mapper.MapToDbMaterial(material)).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
