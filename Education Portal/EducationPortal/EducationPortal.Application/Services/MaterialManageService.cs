using EducationPortal.Application.Commands;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Services
{
    internal class MaterialManageService : IMaterialManageService
    {
        private readonly IBookRepository _bookRepository
            ;
        private readonly CreateBook _createBook;
        private readonly CreateVideo _createVideo;
        private readonly CreateArticle _createArticle;

        public MaterialManageService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
            _createBook = new CreateBook(_bookRepository);
            _createVideo = new CreateVideo(_bookRepository);
            _createArticle = new CreateArticle(_bookRepository);
        }

        public List<BookMaterial> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        public void SetBook(BookMaterial bookMaterial)
        {
            //_createBook.TryCreateBook(bookMaterial);
        }

        public void SetVideo(VideoMaterial videoMaterial)
        {
            // _createVideo.TryCreateVideo(videoMaterial);
        }

        public void SetArticle(ArticleMaterial articleMaterial)
        {
            //_createArticle.TryCreateArticle(articleMaterial);
        }

        public void UpdateBook(string name, BookMaterial updatedMaterial)
        {
            _bookRepository.UpdateBook(name, updatedMaterial);
        }

        public bool DeleteBook(string name)
        {
            return _bookRepository.DeleteBook(name);
        }
    }
}
