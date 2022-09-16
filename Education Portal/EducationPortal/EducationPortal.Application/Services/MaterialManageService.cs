using EducationPortal.Application.Commands.CreateEntity;
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

        public MaterialManageService(
            IRepository<BookMaterial> bookRepository,
            IRepository<VideoMaterial> videoRepository,
            IRepository<ArticleMaterial> articleRepository
        )
        {
            _bookRepository = bookRepository;
            _videoRepository = videoRepository;
            _articleRepository = articleRepository;
            _createBook = new CreateBook(_bookRepository);
            _createVideo = new CreateVideo(_videoRepository);
            _createArticle = new CreateArticle(_articleRepository);
        }

        public async Task<List<BookMaterial>> GetBooks()
        {
            return await _bookRepository.Find();
        }

        public async Task<BookMaterial?> GetBookByName(string name)
        {
            var bookNameSpecification = new SpecificationBase<BookMaterial>(x => x.Name == name);
            var item = await _bookRepository.Find(bookNameSpecification);
            return item.FirstOrDefault();
        }

        public async Task SetBook(BookMaterial bookMaterial)
        {
            await _createBook.TryCreateBook(bookMaterial);
        }

        public async Task UpdateBook(BookMaterial book, BookMaterial updatedMaterial)
        {
            var bookToUpdate = await _bookRepository.FindById(book.Id);
            bookToUpdate.Name = updatedMaterial.Name;
            bookToUpdate.Author = updatedMaterial.Author;
            bookToUpdate.NumberPages = updatedMaterial.NumberPages;
            bookToUpdate.PublicationDate = updatedMaterial.PublicationDate;
            bookToUpdate.Format = updatedMaterial.Format;
            await _bookRepository.Update(bookToUpdate);
        }

        public async Task DeleteBook(string name)
        {
            var material = await GetBookByName(name);
            if (material != null)
            {
                await _bookRepository.Remove(material);
            }
        }

        public async Task<List<VideoMaterial>> GetVideos()
        {
            return await _videoRepository.Find();
        }

        public async Task<VideoMaterial?> GetVideoByName(string name)
        {
            var videoNameSpecification = new SpecificationBase<VideoMaterial>(x => x.Name == name);
            var item = await _videoRepository.Find(videoNameSpecification);
            return item.FirstOrDefault();
        }

        public async Task SetVideo(VideoMaterial videoMaterial)
        {
            await _createVideo.TryCreateVideo(videoMaterial);
        }

        public async Task UpdateVideo(VideoMaterial video, VideoMaterial updatedMaterial)
        {
            var videoToUpdate = await _videoRepository.FindById(video.Id);
            videoToUpdate.Name = updatedMaterial.Name;
            videoToUpdate.Duration = updatedMaterial.Duration;
            videoToUpdate.Quality = updatedMaterial.Quality;
            await _videoRepository.Update(videoToUpdate);
        }

        public async Task DeleteVideo(string name)
        {
            var video = await GetVideoByName(name);
            if (video != null)
            {
                await _videoRepository.Remove(video);
            }
        }

        public async Task<List<ArticleMaterial>> GetArticle()
        {
            return await _articleRepository.Find();
        }

        public async Task SetArticle(ArticleMaterial articleMaterial)
        {
            await _createArticle.TryCreateArticle(articleMaterial);
        }

        public async Task<ArticleMaterial?> GetArticleByName(string name)
        {
            var articleNameSpecification = new SpecificationBase<ArticleMaterial>(x => x.Name == name);
            var item = await _articleRepository.Find(articleNameSpecification);
            return item.FirstOrDefault();
        }

        public async Task UpdateArticle(ArticleMaterial article, ArticleMaterial updatedMaterial)
        {
            var articleToUpdate = await _articleRepository.FindById(article.Id);
            articleToUpdate.Name = updatedMaterial.Name;
            articleToUpdate.Source = updatedMaterial.Source;
            articleToUpdate.PublicationDate = updatedMaterial.PublicationDate;
            await _articleRepository.Update(articleToUpdate);
        }

        public async Task DeleteArticle(string name)
        {
            var article = await GetArticleByName(name);
            if (article != null)
            {
                await _articleRepository.Remove(article);
            }
        }
    }
}
