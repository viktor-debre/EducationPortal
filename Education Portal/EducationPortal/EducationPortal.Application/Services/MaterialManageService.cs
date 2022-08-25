using EducationPortal.Application.Commands;
using EducationPortal.Domain.Entities.Materials;
using EducationPortal.Domain.Repository;

namespace EducationPortal.Application.Services
{
    internal class MaterialManageService : IMaterialManageService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IVideoRepository _videoRepository;
        private readonly IArticleRepository _articleRepository;

        private readonly CreateBook _createBook;
        private readonly CreateVideo _createVideo;
        private readonly CreateArticle _createArticle;

        public MaterialManageService(IBookRepository bookRepository, IVideoRepository videoRepository, IArticleRepository articleRepository)
        {
            _bookRepository = bookRepository;
            _videoRepository = videoRepository;
            _articleRepository = articleRepository;
            _createBook = new CreateBook(_bookRepository);
            _createVideo = new CreateVideo(_videoRepository);
            _createArticle = new CreateArticle(_articleRepository);
        }

        public List<BookMaterial> GetBooks()
        {
            return _bookRepository.GetBooks();
        }

        public void SetBook(BookMaterial bookMaterial)
        {
            _createBook.TryCreateBook(bookMaterial);
        }

        public void UpdateBook(string name, BookMaterial updatedMaterial)
        {
            _bookRepository.UpdateBook(name, updatedMaterial);
        }

        public void DeleteBook(string name)
        {
            var id = _bookRepository.GetBooks().FirstOrDefault(x => x.Name == name).Id;
            if (id != null)
            {
                _bookRepository.DeleteBook(id);
            }
        }

        public List<VideoMaterial> GetVideo()
        {
            return _videoRepository.GetVideos();
        }

        public void SetVideo(VideoMaterial videoMaterial)
        {
            _createVideo.TryCreateVideo(videoMaterial);
        }

        public void UpdateVideo(string name, VideoMaterial updatedMaterial)
        {
            _videoRepository.UpdateVideo(name, updatedMaterial);
        }

        public void DeleteVideo(string name)
        {
            var id = _videoRepository.GetVideos().FirstOrDefault(x => x.Name == name).Id;
            if (id != null)
            {
                _videoRepository.DeleteVideo(id);
            }
        }

        public List<ArticleMaterial> GetArticle()
        {
            return _articleRepository.GetArticle();
        }

        public void SetArticle(ArticleMaterial articleMaterial)
        {
            _createArticle.TryCreateArticle(articleMaterial);
        }

        public void UpdateArticle(ArticleMaterial article, ArticleMaterial updatedMaterial)
        {
            var articleToUpdate = _articleRepository.GetArticle().FirstOrDefault(a => a.Id == article.Id);
            articleToUpdate.Name = updatedMaterial.Name;
            articleToUpdate.Source = updatedMaterial.Source;
            articleToUpdate.PublicationDate = updatedMaterial.PublicationDate;
            _articleRepository.UpdateArticle(articleToUpdate);
        }

        public void DeleteArticle(string name)
        {
            var id = _articleRepository.GetArticle().FirstOrDefault(x => x.Name == name).Id;
            if (id != null)
            {
                _articleRepository.DeleteArticle(id);
            }
        }
    }
}
