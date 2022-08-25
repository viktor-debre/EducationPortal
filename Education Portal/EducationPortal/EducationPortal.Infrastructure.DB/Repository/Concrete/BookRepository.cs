using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Infrastructure.DB.Repository
{
    internal class BookRepository : IBookRepository
    {
        private readonly PortalContext _context;
        private readonly MapperForEntities _mapper;

        public BookRepository(PortalContext context)
        {
            _context = context;
            _mapper = new MapperForEntities(context);
        }

        public void DeleteBook(BookMaterial material)
        {
            _context.Materials.Remove((DbMaterial)_mapper.MapToDbEntity(material));
            Save();
        }

        public BookMaterial? GetBookById(int id)
        {
            return (BookMaterial?)_context.Materials.Find(id).MapToDomainMaterial();
        }

        public List<BookMaterial> GetBooks()
        {
            List<BookMaterial> books = new List<BookMaterial>();
            foreach (var book in _context.Materials)
            {
                if (book is DbBookMaterial)
                {
                    books.Add((BookMaterial)book.MapToDomainMaterial());
                }
            }

            return books;
        }

        public void SetBook(BookMaterial material)
        {
            _context.Materials.Add((DbMaterial)_mapper.MapToDbEntity(material));
            Save();
        }

        public void UpdateBook(BookMaterial material)
        {
            _context.Entry((DbMaterial)_mapper.MapToDbEntity(material)).State = EntityState.Modified;
            Save();
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
