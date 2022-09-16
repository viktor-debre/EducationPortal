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

        public async Task SetMaterial(MaterialView material)
        {
            await _materialService.SetMaterial(_mapper.MapMaterialToDomainModel(material));
        }

        public async Task RemoveMaterial(MaterialView material)
        {
            await _materialService.DeleteMaterial(_mapper.MapMaterialToDomainModel(material));
        }

        public async Task UpdateMaterial(MaterialView material)
        {
            var updatedMaterial = _mapper.MapMaterialToDomainModel(material);
            await _materialService.UpdateMaterial(updatedMaterial);
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
