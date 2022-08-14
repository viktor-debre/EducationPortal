using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleMaterialManager
    {
        private const int WrongCommandDelay = 1500;
        private readonly IMaterialManageService _materialManageService;
        private readonly InputHandler _inputHandler = new InputHandler();

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
                OutputAllBooks();
                OutputAllVideos();
                OutputAllArticles();

                Console.WriteLine("Editing material menu:\n" +
                    "1 - add book,   \t" + "1d  - delete book,   \t" + "1u - update book\n" +
                    "2 - add video,  \t" + "2d  - delete video,  \t" + "2u - update video\n" +
                    "3 - add article,\t" + "3d  - delete article,\t" + "3u - update article\n" +
                    "quit - go to previous menu");
                string input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "quit":
                        return;
                    case "1":
                        AddBook();
                        break;
                    case "1d":
                        DeleteBook();
                        break;
                    case "1u":
                        UpdateBook();
                        break;
                    case "2":
                        AddVideo();
                        break;
                    case "2d":
                        DeleteVideo();
                        break;
                    case "2u":
                        UpdateVideo();
                        break;
                    case "3":
                        AddArticle();
                        break;
                    case "3d":
                        DeleteArticle();
                        break;
                    case "3u":
                        UpdateArticle();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        Thread.Sleep(WrongCommandDelay);
                        break;
                }
            }
        }

        private void OutputAllBooks()
        {
            List<BookMaterial> bookMaterials = _materialManageService.GetBooks();
            Console.WriteLine("Books:");
            foreach (BookMaterial book in bookMaterials)
            {
                Console.WriteLine($"{book.Name} NumberOfPages: {book.NumberPages} {book.Author} format: {book.Format} publication date: {book.PublicationDate.ToString("MM/dd/yyyy")}");
            }
        }

        private void OutputAllVideos()
        {
            List<VideoMaterial> videoMaterials = _materialManageService.GetVideo();
            Console.WriteLine("Videos:");
            foreach (VideoMaterial video in videoMaterials)
            {
                Console.WriteLine($"{video.Name} Duration: {video.Duration} Quality: {video.Quality}");
            }
        }

        private void OutputAllArticles()
        {
            List<ArticleMaterial> articleMaterials = _materialManageService.GetArticle();
            Console.WriteLine("Articles:");
            foreach (ArticleMaterial article in articleMaterials)
            {
                Console.WriteLine($"{article.Name} Source: {article.Source} PublicationDate: {article.PublicationDate}");
            }
        }

        private void AddBook()
        {
            string operation = "adding book";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            string author;
            if (!_inputHandler.TryInputStringValue(out author, "author name", operation))
            {
                return;
            }

            string format;
            if (!_inputHandler.TryInputStringValue(out format, "format: ", operation))
            {
                return;
            }

            int numberOfPages;
            if (!_inputHandler.TryInputIntValue(out numberOfPages, "number of pages", operation))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", operation))
            {
                return;
            }

            BookMaterial bookMaterial = new BookMaterial
            {
                Name = name,
                Author = author,
                Format = format,
                NumberPages = numberOfPages,
                PublicationDate = publicationDate
            };
            _materialManageService.SetBook(bookMaterial);
        }

        private void DeleteBook()
        {
            string operation = "deleting book";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }
            else
            {
                _materialManageService.DeleteBook(name);
            }
        }

        private void UpdateBook()
        {
            string operation = "updating book";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "new name", operation))
            {
                return;
            }

            string author;
            if (!_inputHandler.TryInputStringValue(out author, "author name", operation))
            {
                return;
            }

            string format;
            if (!_inputHandler.TryInputStringValue(out format, "format", operation))
            {
                return;
            }

            int numberOfPages;
            if (!_inputHandler.TryInputIntValue(out numberOfPages, "number of pages", operation))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", operation))
            {
                return;
            }

            BookMaterial bookMaterial = new BookMaterial
            {
                Name = newName,
                Author = author,
                Format = format,
                NumberPages = numberOfPages,
                PublicationDate = publicationDate
            };
            _materialManageService.UpdateBook(name, bookMaterial);
        }

        private void AddVideo()
        {
            string operation = "adding video";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            string quality;
            if (!_inputHandler.TryInputStringValue(out quality, "quality", operation))
            {
                return;
            }

            TimeSpan duration;
            if (!_inputHandler.TryInputTimeSpanValue(out duration, "duration", operation))
            {
                return;
            }

            VideoMaterial videoMaterial = new VideoMaterial
            {
                Name = name,
                Duration = duration,
                Quality = quality
            };
            _materialManageService.SetVideo(videoMaterial);
        }

        private void DeleteVideo()
        {
            string operation = "deleting video";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }
            else
            {
                _materialManageService.DeleteVideo(name);
            }
        }

        private void UpdateVideo()
        {
            string operation = "updating video";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "name", operation))
            {
                return;
            }

            string quality;
            if (!_inputHandler.TryInputStringValue(out quality, "quality", operation))
            {
                return;
            }

            TimeSpan duration;
            if (!_inputHandler.TryInputTimeSpanValue(out duration, "duration", operation))
            {
                return;
            }

            VideoMaterial videoMaterial = new VideoMaterial
            {
                Name = newName,
                Duration = duration,
                Quality = quality
            };
            _materialManageService.UpdateVideo(name, videoMaterial);
        }

        private void AddArticle()
        {
            string operation = "adding article";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            string source;
            if (!_inputHandler.TryInputStringValue(out source, "source", operation))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", operation))
            {
                return;
            }

            ArticleMaterial articleMaterial = new ArticleMaterial
            {
                Name = name,
                Source = source,
                PublicationDate = publicationDate
            };
            _materialManageService.SetArticle(articleMaterial);
        }

        private void DeleteArticle()
        {
            string operation = "delete article";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }
            else
            {
                _materialManageService.DeleteBook(name);
            }
        }

        private void UpdateArticle()
        {
            string operation = "updating article";

            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "new name", operation))
            {
                return;
            }

            string source;
            if (!_inputHandler.TryInputStringValue(out source, "source", operation))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", operation))
            {
                return;
            }

            ArticleMaterial articleMaterial = new ArticleMaterial
            {
                Name = newName,
                Source = source,
                PublicationDate = publicationDate
            };
            _materialManageService.UpdateArticle(name, articleMaterial);
        }
    }
}
