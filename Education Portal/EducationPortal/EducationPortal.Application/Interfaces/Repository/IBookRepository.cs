using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Repository
{
    public interface IBookRepository
    {
        public List<BookMaterial> Books { get; }

        public List<BookMaterial> GetBooks();

        public BookMaterial GetBookByName(string name);

        public void SetBook(BookMaterial material);

        public void UpdateBook(string name, BookMaterial updatedMaterial);

        public bool DeleteBook(string name);
    }
}
