using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleMaterialManager
    {
        private readonly IMaterialManageService _materialManageService;

        public ConsoleMaterialManager(IMaterialManageService materialManageService)
        {
            _materialManageService = materialManageService;
        }

        public void EditMaterials()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Materials:");
                List<BookMaterial> bookMaterials = _materialManageService.GetBooks();
                Console.WriteLine("Books:");
                foreach (BookMaterial book in bookMaterials)
                {
                    Console.WriteLine($"{book.Name} NumberOfPages: {book.NumberPages} {book.Author} format: {book.Format} + {book.PublicationDate}");
                }
                List<VideoMaterial> videoMaterials = _materialManageService.GetVideo();
                Console.WriteLine("Videos:");
                foreach (VideoMaterial video in videoMaterials)
                {
                    Console.WriteLine($"{video.Name} Duration: {video.Duration} Quality: {video.Quality}");
                }
                List<ArticleMaterial> articleMaterials = _materialManageService.GetArticle();
                Console.WriteLine("Articles:");
                foreach (ArticleMaterial article in articleMaterials)
                {
                    Console.WriteLine($"{article.Name} Source: {article.Source} PublicationDate: {article.publicationDate}");
                }
                Console.WriteLine("Editing material menu:\n" +
                    "1 - add book\n" +
                    "2 - add video\n" +
                    "3 - add article");
                string input = Console.ReadLine() ?? "";
                if (input == "1")
                {
                    BookMaterial bookMaterial = new BookMaterial 
                    { 
                        Name = "new_book", 
                        NumberPages = 10, 
                        Author = "Viktor", 
                        Format = ".txt", 
                        PublicationDate = DateTime.Now 
                    };
                    _materialManageService.SetBook(bookMaterial);
                }

            }
        }

    }
}
