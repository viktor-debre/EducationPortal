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

        public void UpdateBook(BookMaterial article, BookMaterial updatedMaterial)
        {
            var bookToUpdate = _bookRepository.GetBooks().FirstOrDefault(a => a.Id == article.Id);
            bookToUpdate.Name = updatedMaterial.Name;
            bookToUpdate.Author = updatedMaterial.Author;
            bookToUpdate.NumberPages = updatedMaterial.NumberPages;
            bookToUpdate.PublicationDate = updatedMaterial.PublicationDate;
            bookToUpdate.Format = updatedMaterial.Format;
            _bookRepository.UpdateBook(bookToUpdate);
        }

        public void DeleteBook(string name)
        {
            var material = _bookRepository.GetBooks().FirstOrDefault(x => x.Name == name);
            if (material != null)
            {
                _bookRepository.DeleteBook(material);
            }
        }

        public List<VideoMaterial> GetVideos()
        {
            return _videoRepository.GetVideos();
        }

        public void SetVideo(VideoMaterial videoMaterial)
        {
            _createVideo.TryCreateVideo(videoMaterial);
        }

        public void UpdateVideo(VideoMaterial video, VideoMaterial updatedMaterial)
        {
            var videoToUpdate = _videoRepository.GetVideos().FirstOrDefault(a => a.Id == video.Id);
            videoToUpdate.Name = updatedMaterial.Name;
            videoToUpdate.Duration = updatedMaterial.Duration;
            videoToUpdate.Quality = updatedMaterial.Quality;
            _videoRepository.UpdateVideo(videoToUpdate);
        }

        public void DeleteVideo(string name)
        {
            var video = _videoRepository.GetVideos().FirstOrDefault(x => x.Name == name);
            if (video != null)
            {
                _videoRepository.DeleteVideo(video);
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
            var article = _articleRepository.GetArticle().FirstOrDefault(x => x.Name == name);
            if (article != null)
            {
                _articleRepository.DeleteArticle(article);
            }
        }
    }
}
