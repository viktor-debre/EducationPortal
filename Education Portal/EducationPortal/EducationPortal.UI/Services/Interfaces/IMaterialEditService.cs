namespace EducationPortal.UI.Services.Interfaces
{
    public interface IMaterialEditService
    {
        public Task<List<MaterialView>> GetMaterials();

        public Task SetMaterial(MaterialView material);

        public Task RemoveMaterial(MaterialView material);

        public Task UpdateMaterial(MaterialView material);

        public Task<MaterialView> GetByIdMaterial(int id);
    }
}
