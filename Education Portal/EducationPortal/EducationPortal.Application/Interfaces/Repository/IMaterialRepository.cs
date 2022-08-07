using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Repository
{
    public interface IMaterialRepository
    {
        public List<Material> Materials { get; }

        public List<Material> GetMaterials();

        public Material GetMaterialByName(string name);

        public void SetMaterial(Material material);

        public void UpdateMaterial(string name, Material updatedMaterial);

        public void DeleteMaterial(string name);
    }
}
