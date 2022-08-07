using EducationPortal.Application.Interfaces.Repository;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Infrastructure.Repositories
{
    internal class MaterialRepository : IMaterialRepository
    {
        public List<Material> Materials { get; set; }
        private const string materialPath = @"D:\work\material.json";
        private readonly StorageManager<Material> _storage = new StorageManager<Material>();

        public MaterialRepository()
        {
            Materials = new List<Material>();
        }

        public List<Material> GetMaterials()
        {
            List<Material> materials = _storage.ExctractItemsFromStorage(materialPath);
            if (materials != null)
            {
                Materials = materials;
            }
            return Materials;
        }

        public Material? GetMaterialByName(string name)
        {
            return Materials.FirstOrDefault(x => x.Name == name);
        }

        public void SetMaterial(Material material)
        {
            Materials.Add(material);
            _storage.AddItemToStorage(Materials, materialPath);
        }

        public void UpdateMaterial(string name, Material updatedMaterial)
        {
            if (DeleteMaterial(name))
            {
                Materials.Add(updatedMaterial);
                _storage.AddItemToStorage(Materials, materialPath);
            }
        }

        public bool DeleteMaterial(string name)
        {
            var material = GetMaterialByName(name);
            if (material != null)
            {
                Materials.Remove(material);
                return true;
            }
            return false;
        }

    }
}
