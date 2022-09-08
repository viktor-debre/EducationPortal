using EducationPortal.Application.Commands;
using EducationPortal.Domain.Helpers.Specification;

namespace EducationPortal.Application.Services
{
    internal class MaterialManageService : IMaterialManageService
    {
        private readonly IRepository<BookMaterial> _bookRepository;
        private readonly IRepository<VideoMaterial> _videoRepository;
        private readonly IRepository<ArticleMaterial> _articleRepository;

        private readonly CreateBook _createBook;
        private readonly CreateVideo _createVideo;
        private readonly CreateArticle _createArticle;

        public MaterialManageService(IRepository<BookMaterial> bookRepository, IRepository<VideoMaterial> videoRepository, IRepository<ArticleMaterial> articleRepository)
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
            return _bookRepository.Find();
        }

        public BookMaterial? GetBookByName(string name)
        {
            var bookNameSpecification = new SpecificationBase<BookMaterial>(x => x.Name == name);
            return _bookRepository.Find(bookNameSpecification).FirstOrDefault();
        }

        public void SetBook(BookMaterial bookMaterial)
        {
            _createBook.TryCreateBook(bookMaterial);
        }

        public void UpdateBook(BookMaterial book, BookMaterial updatedMaterial)
        {
            var bookToUpdate = _bookRepository.FindById(book.Id);
            bookToUpdate.Name = updatedMaterial.Name;
            bookToUpdate.Author = updatedMaterial.Author;
            bookToUpdate.NumberPages = updatedMaterial.NumberPages;
            bookToUpdate.PublicationDate = updatedMaterial.PublicationDate;
            bookToUpdate.Format = updatedMaterial.Format;
            _bookRepository.Update(bookToUpdate);
        }

        public void DeleteBook(string name)
        {
            var material = GetBookByName(name);
            if (material != null)
            {
                _bookRepository.Remove(material);
            }
        }

        public List<VideoMaterial> GetVideos()
        {
            return _videoRepository.Find();
        }

        public VideoMaterial? GetVideosByName(string name)
        {
            var videoNameSpecification = new SpecificationBase<VideoMaterial>(x => x.Name == name);
            return _videoRepository.Find(videoNameSpecification).FirstOrDefault();
        }

        public void SetVideo(VideoMaterial videoMaterial)
        {
            _createVideo.TryCreateVideo(videoMaterial);
        }

        public void UpdateVideo(VideoMaterial video, VideoMaterial updatedMaterial)
        {
            var videoToUpdate = _videoRepository.FindById(video.Id);
            videoToUpdate.Name = updatedMaterial.Name;
            videoToUpdate.Duration = updatedMaterial.Duration;
            videoToUpdate.Quality = updatedMaterial.Quality;
            _videoRepository.Update(videoToUpdate);
        }

        public void DeleteVideo(string name)
        {
            var video = GetVideosByName(name);
            if (video != null)
            {
                _videoRepository.Remove(video);
            }
        }

        public List<ArticleMaterial> GetArticle()
        {
            return _articleRepository.Find();
        }

        public void SetArticle(ArticleMaterial articleMaterial)
        {
            _createArticle.TryCreateArticle(articleMaterial);
        }

        public ArticleMaterial? GetArticleByName(string name)
        {
            var articleNameSpecification = new SpecificationBase<ArticleMaterial>(x => x.Name == name);
            return _articleRepository.Find(articleNameSpecification).FirstOrDefault();
        }

        public void UpdateArticle(ArticleMaterial article, ArticleMaterial updatedMaterial)
        {
            var articleToUpdate = _articleRepository.FindById(article.Id);
            articleToUpdate.Name = updatedMaterial.Name;
            articleToUpdate.Source = updatedMaterial.Source;
            articleToUpdate.PublicationDate = updatedMaterial.PublicationDate;
            _articleRepository.Update(articleToUpdate);
        }

        public void DeleteArticle(string name)
        {
            var article = GetArticleByName(name);
            if (article != null)
            {
                _articleRepository.Remove(article);
            }
        }
    }
}
