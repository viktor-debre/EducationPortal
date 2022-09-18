using EducationPortal.Application.Interfaces.Shared;
using EducationPortal.Domain.Entities;
using EducationPortal.UI.Models.Mapping;

namespace EducationPortal.UI.Services.Implementation
{
    public class MaterialEditService : IMaterialEditService
    {
        private readonly IMaterialManageService _materialService;
        private readonly IMapper _mapper;

        public MaterialEditService(IMaterialManageService materialService, IMapper mapper)
        {
            _materialService = materialService;
            _mapper = mapper;
        }

        public async Task<List<MaterialView>> GetMaterials()
        {
            List<MaterialView> materials = new List<MaterialView>();
            var materialsInStorage = await _materialService.GetMaterials();
            foreach (var material in materialsInStorage)
            {
                materials.Add(_mapper.MapMaterialToViewModel(material));
            }

            return materials;
        }

        public async Task SetArticle(ArticleView material)
        {
            await _materialService.SetArticle((ArticleMaterial)_mapper.MapMaterialToDomainModel(material));
        }

        public async Task SetBook(BookView material)
        {
            await _materialService.SetBook((BookMaterial)_mapper.MapMaterialToDomainModel(material));
        }

        public async Task SetVideo(VideoView material)
        {
            await _materialService.SetVideo((VideoMaterial)_mapper.MapMaterialToDomainModel(material));
        }

        public async Task RemoveMaterial(MaterialView material)
        {
            await _materialService.DeleteMaterial(_mapper.MapMaterialToDomainModel(material));
        }

        public async Task UpdateArticle(ArticleView material)
        {
            var updatedMaterial = (ArticleMaterial)_mapper.MapMaterialToDomainModel(material);
            await _materialService.UpdateArticle(updatedMaterial);
        }

        public async Task UpdateBook(BookView material)
        {
            var updatedMaterial = (BookMaterial)_mapper.MapMaterialToDomainModel(material);
            await _materialService.UpdateBook(updatedMaterial);
        }

        public async Task UpdateVideo(VideoView material)
        {
            var updatedMaterial = (VideoMaterial)_mapper.MapMaterialToDomainModel(material);
            await _materialService.UpdateVideo(updatedMaterial);
        }

        public async Task<MaterialView> GetByIdMaterial(int id)
        {
            List<Material> materials = new List<Material>();
            materials.AddRange(await _materialService.GetBooks());
            materials.AddRange(await _materialService.GetVideos());
            materials.AddRange(await _materialService.GetArticles());
            var material = materials.Find(x => x.Id == id);

            return _mapper.MapMaterialToViewModel(material);
        }
    }
}
