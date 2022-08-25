using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Presentation.Application
{
    internal class MaterialManager
    {
        private readonly IMaterialManageService _materialManageService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public MaterialManager(IMaterialManageService materialManageService)
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

                Console.WriteLine(MenuStrings.MATERIAL_MENU);
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
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
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
                Console.WriteLine("---<>---");
            }
        }

        private void OutputAllVideos()
        {
            List<VideoMaterial> videoMaterials = _materialManageService.GetVideos();
            Console.WriteLine("Videos:");
            foreach (VideoMaterial video in videoMaterials)
            {
                Console.WriteLine($"{video.Name} Duration: {video.Duration} Quality: {video.Quality}");
                Console.WriteLine("---<>---");
            }
        }

        private void OutputAllArticles()
        {
            List<ArticleMaterial> articleMaterials = _materialManageService.GetArticle();
            Console.WriteLine("Articles:");
            foreach (ArticleMaterial article in articleMaterials)
            {
                Console.WriteLine($"{article.Name} Source: {article.Source} PublicationDate: {article.PublicationDate}");
                Console.WriteLine("---<>---");
            }
        }

        private void AddBook()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.BOOK))
            {
                return;
            }

            string author;
            if (!_inputHandler.TryInputStringValue(out author, "author name", Operation.ADDING, EntityName.BOOK))
            {
                return;
            }

            string format;
            if (!_inputHandler.TryInputStringValue(out format, "format: ", Operation.ADDING, EntityName.BOOK))
            {
                return;
            }

            int numberOfPages;
            if (!_inputHandler.TryInputIntValue(out numberOfPages, "number of pages", Operation.ADDING, EntityName.BOOK))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", Operation.ADDING, EntityName.BOOK))
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
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.BOOK))
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
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.BOOK))
            {
                return;
            }

            var existingBook = _materialManageService.GetBooks().FirstOrDefault(x => x.Name == name);
            if (existingBook == null)
            {
                Console.WriteLine($"{EntityName.BOOK} {Result.DOES_NOT_EXIST}, {Operation.UPDATING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "new name", Operation.UPDATING, EntityName.BOOK))
            {
                return;
            }

            string author;
            if (!_inputHandler.TryInputStringValue(out author, "author name", Operation.UPDATING, EntityName.BOOK))
            {
                return;
            }

            string format;
            if (!_inputHandler.TryInputStringValue(out format, "format", Operation.UPDATING, EntityName.BOOK))
            {
                return;
            }

            int numberOfPages;
            if (!_inputHandler.TryInputIntValue(out numberOfPages, "number of pages", Operation.UPDATING, EntityName.BOOK))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", Operation.UPDATING, EntityName.BOOK))
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
            _materialManageService.UpdateBook(existingBook, bookMaterial);
        }

        private void AddVideo()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.VIDEO))
            {
                return;
            }

            string quality;
            if (!_inputHandler.TryInputStringValue(out quality, "quality", Operation.ADDING, EntityName.VIDEO))
            {
                return;
            }

            TimeSpan duration;
            if (!_inputHandler.TryInputTimeSpanValue(out duration, "duration", Operation.ADDING, EntityName.VIDEO))
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
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.VIDEO))
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
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.VIDEO))
            {
                return;
            }

            var existingVideo = _materialManageService.GetVideos().FirstOrDefault(x => x.Name == name);
            if (existingVideo == null)
            {
                Console.WriteLine($"{EntityName.VIDEO} {Result.DOES_NOT_EXIST}, {Operation.UPDATING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "name", Operation.UPDATING, EntityName.VIDEO))
            {
                return;
            }

            string quality;
            if (!_inputHandler.TryInputStringValue(out quality, "quality", Operation.UPDATING, EntityName.VIDEO))
            {
                return;
            }

            TimeSpan duration;
            if (!_inputHandler.TryInputTimeSpanValue(out duration, "duration", Operation.UPDATING, EntityName.VIDEO))
            {
                return;
            }

            VideoMaterial videoMaterial = new VideoMaterial
            {
                Name = newName,
                Duration = duration,
                Quality = quality
            };
            _materialManageService.UpdateVideo(existingVideo, videoMaterial);
        }

        private void AddArticle()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.ARTICLE))
            {
                return;
            }

            string source;
            if (!_inputHandler.TryInputStringValue(out source, "source", Operation.ADDING, EntityName.ARTICLE))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", Operation.ADDING, EntityName.ARTICLE))
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
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.ARTICLE))
            {
                return;
            }
            else
            {
                _materialManageService.DeleteArticle(name);
            }
        }

        private void UpdateArticle()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.ARTICLE))
            {
                return;
            }

            var existingArticle = _materialManageService.GetArticle().FirstOrDefault(x => x.Name == name);
            if (existingArticle == null)
            {
                Console.WriteLine($"{EntityName.ARTICLE} {Result.DOES_NOT_EXIST}, {Operation.UPDATING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "new name", Operation.UPDATING, EntityName.ARTICLE))
            {
                return;
            }

            string source;
            if (!_inputHandler.TryInputStringValue(out source, "source", Operation.UPDATING, EntityName.ARTICLE))
            {
                return;
            }

            DateTime publicationDate;
            if (!_inputHandler.TryInputDateTimeValue(out publicationDate, "publication date", Operation.UPDATING, EntityName.ARTICLE))
            {
                return;
            }

            ArticleMaterial articleMaterial = new ArticleMaterial
            {
                Name = newName,
                Source = source,
                PublicationDate = publicationDate
            };
            _materialManageService.UpdateArticle(existingArticle, articleMaterial);
        }
    }
}
