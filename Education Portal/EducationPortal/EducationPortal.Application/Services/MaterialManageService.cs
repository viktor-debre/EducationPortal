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

        public async Task<List<Material>> GetMaterials()
        {
            List<Material> materials = new List<Material>();
            materials.AddRange(await GetBooks());
            materials.AddRange(await GetArticles());
            materials.AddRange(await GetVideos());
            return materials;
        }

        public async Task SetMaterial(Material material)
        {
            if (material is BookMaterial book)
            {
                await SetBook(book);
            }

            if (material is VideoMaterial video)
            {
                await SetVideo(video);
            }

            if (material is ArticleMaterial article)
            {
                await SetArticle(article);
            }

            throw new Exception("Unknown type material!");
        }

        public async Task DeleteMaterial(Material material)
        {
            if (material is BookMaterial book)
            {
                await DeleteBook(book);
            }

            if (material is VideoMaterial video)
            {
                await DeleteVideo(video);
            }

            if (material is ArticleMaterial article)
            {
                await DeleteArticle(article);
            }

            throw new Exception("Unknown type material!");
        }

        public async Task UpdateMaterial(Material material)
        {
            if (material is BookMaterial book)
            {
                await UpdateBook(book);
            }

            if (material is VideoMaterial video)
            {
                await UpdateVideo(video);
            }

            if (material is ArticleMaterial article)
            {
                await UpdateArticle(article);
            }

            throw new Exception("Unknown type material!");
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

        public async Task UpdateBook(BookMaterial book)
        {
            var bookToUpdate = await _bookRepository.FindById(book.Id);
            bookToUpdate.Name = book.Name;
            bookToUpdate.Author = book.Author;
            bookToUpdate.NumberPages = book.NumberPages;
            bookToUpdate.PublicationDate = book.PublicationDate;
            bookToUpdate.Format = book.Format;
            await _bookRepository.Update(bookToUpdate);
        }

        public async Task DeleteBook(BookMaterial video)
        {
            await _bookRepository.Remove(video);
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

        public async Task UpdateVideo(VideoMaterial video)
        {
            var videoToUpdate = await _videoRepository.FindById(video.Id);
            videoToUpdate.Name = video.Name;
            videoToUpdate.Duration = video.Duration;
            videoToUpdate.Quality = video.Quality;
            await _videoRepository.Update(videoToUpdate);
        }

        public async Task DeleteVideo(VideoMaterial video)
        {
            await _videoRepository.Remove(video);
        }

        public async Task<List<ArticleMaterial>> GetArticles()
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

        public async Task UpdateArticle(ArticleMaterial article)
        {
            var articleToUpdate = await _articleRepository.FindById(article.Id);
            articleToUpdate.Name = article.Name;
            articleToUpdate.Source = article.Source;
            articleToUpdate.PublicationDate = article.PublicationDate;
            await _articleRepository.Update(articleToUpdate);
        }

        public async Task DeleteArticle(ArticleMaterial article)
        {
            await _articleRepository.Remove(article);
        }
    }
}
