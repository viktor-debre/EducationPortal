using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Application.Interfaces.Shared
{
    public interface IMaterialManageService
    {
        public List<BookMaterial> GetBooks();

        public void SetBook(BookMaterial book);

        //public void SetVideo(VideoMaterial video);

        //public void SetArticle(ArticleMaterial article);

        public void UpdateBook(string name, BookMaterial updatedMaterial);

        public bool DeleteBook(string name);
    }
}
