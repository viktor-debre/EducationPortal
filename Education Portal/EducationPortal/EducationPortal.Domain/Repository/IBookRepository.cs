namespace EducationPortal.Domain.Repository
{
    public interface IBookRepository
    {
        public List<BookMaterial> GetBooks();

        public BookMaterial GetBookById(int id);

        public void SetBook(BookMaterial material);

        public void UpdateBook(string name, BookMaterial updatedMaterial);

        public void DeleteBook(string name);

        public void Save();
    }
}
