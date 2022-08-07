using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IMaterialManageService
    {
        public List<Material> GetMaterials();

        public void SetBook(BookMaterial book);

        public void SetVideo(VideoMaterial video);

        public void SetArticle(ArticleMaterial article);

        public void UpdateMaterial(string name, Material updatedMaterial);

        public bool DeleteMaterial(string name);
    }
}
