using EducationPortal.Application.Commands;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Services
{
    internal class MaterialManageService : IMaterialManageService
    {
        private readonly IMaterialRepository _materialRepository;
        private readonly CreateBook _createBook;
        private readonly CreateVideo _createVideo;
        private readonly CreateArticle _createArticle;

        public MaterialManageService(IMaterialRepository materialRepository)
        {
            _materialRepository = materialRepository;
            _createBook = new CreateBook(_materialRepository);
            _createVideo = new CreateVideo(_materialRepository);
            _createArticle = new CreateArticle(_materialRepository);
        }

        public List<Material> GetMaterials()
        {
           return _materialRepository.GetMaterials();
        }

        public void SetBook(BookMaterial bookMaterial)
        {
            _createBook.TryCreateBook(bookMaterial);
        }

        public void SetVideo(VideoMaterial videoMaterial)
        {
            _createVideo.TryCreateVideo(videoMaterial);
        }

        public void SetArticle(ArticleMaterial articleMaterial)
        {
            _createArticle.TryCreateArticle(articleMaterial);
        }

        public void UpdateMaterial(string name, Material updatedMaterial)
        {
            _materialRepository.UpdateMaterial(name, updatedMaterial);
        }

        public bool DeleteMaterial(string name)
        {
            return _materialRepository.DeleteMaterial(name);
        }

    }
}
