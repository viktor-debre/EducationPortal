namespace EducationPortal.Domain.Repository
{
    public interface IBookRepository
    {
        public List<BookMaterial> GetBooks();

        public BookMaterial GetBookById(int id);

        public void SetBook(BookMaterial material);

        public void UpdateBook(BookMaterial material);

        public void DeleteBook(BookMaterial material);

        public void Save();
    }
}
