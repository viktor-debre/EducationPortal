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

        public async Task EditMaterials()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Materials:");
                await OutputAllBooks();
                await OutputAllVideos();
                await OutputAllArticles();

                Console.WriteLine(MenuStrings.MATERIAL_MENU);
                string input = Console.ReadLine() ?? "";

                switch (input)
                {
                    case "quit":
                        return;
                    case "1":
                        await AddBook();
                        break;
                    case "1d":
                        await DeleteBook();
                        break;
                    case "1u":
                        await UpdateBook();
                        break;
                    case "2":
                        await AddVideo();
                        break;
                    case "2d":
                        await DeleteVideo();
                        break;
                    case "2u":
                        await UpdateVideo();
                        break;
                    case "3":
                        await AddArticle();
                        break;
                    case "3d":
                        await DeleteArticle();
                        break;
                    case "3u":
                        await UpdateArticle();
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private async Task OutputAllBooks()
        {
            List<BookMaterial> bookMaterials = await _materialManageService.GetBooks();
            Console.WriteLine("Books:");
            foreach (BookMaterial book in bookMaterials)
            {
                Console.WriteLine($"{book.Name} NumberOfPages: {book.NumberPages} {book.Author} format: {book.Format} publication date: {book.PublicationDate.ToString("MM/dd/yyyy")}");
                Console.WriteLine("---<>---");
            }
        }

        private async Task OutputAllVideos()
        {
            List<VideoMaterial> videoMaterials = await _materialManageService.GetVideos();
            Console.WriteLine("Videos:");
            foreach (VideoMaterial video in videoMaterials)
            {
                Console.WriteLine($"{video.Name} Duration: {video.Duration} Quality: {video.Quality}");
                Console.WriteLine("---<>---");
            }
        }

        private async Task OutputAllArticles()
        {
            List<ArticleMaterial> articleMaterials = await _materialManageService.GetArticles();
            Console.WriteLine("Articles:");
            foreach (ArticleMaterial article in articleMaterials)
            {
                Console.WriteLine($"{article.Name} Source: {article.Source} PublicationDate: {article.PublicationDate}");
                Console.WriteLine("---<>---");
            }
        }

        private async Task AddBook()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.BOOK))
            {
                return;
            }

            var existingBook = await _materialManageService.GetBookByName(name);
            if (existingBook != null)
            {
                Console.WriteLine($"{EntityName.BOOK} {Result.ALREADY_EXISTS}, {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
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
            await _materialManageService.SetBook(bookMaterial);
        }

        private async Task DeleteBook()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.BOOK))
            {
                return;
            }

            var existingBook = await _materialManageService.GetBookByName(name);
            if (existingBook == null)
            {
                Console.WriteLine($"{EntityName.BOOK} {Result.DOES_NOT_EXIST}, {Operation.DELETING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }
            else
            {
                await _materialManageService.DeleteBook(name);
            }
        }

        private async Task UpdateBook()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.BOOK))
            {
                return;
            }

            var existingBook = await _materialManageService.GetBookByName(name);
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

            existingBook.Name = newName;
            existingBook.Author = author;
            existingBook.Format = format;
            existingBook.NumberPages = numberOfPages;
            existingBook.PublicationDate = publicationDate;

            await _materialManageService.UpdateBook(existingBook);
        }

        private async Task AddVideo()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.VIDEO))
            {
                return;
            }

            var existingVideo = await _materialManageService.GetVideoByName(name);
            if (existingVideo != null)
            {
                Console.WriteLine($"{EntityName.VIDEO} {Result.ALREADY_EXISTS}, {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
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
            await _materialManageService.SetVideo(videoMaterial);
        }

        private async Task DeleteVideo()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.VIDEO))
            {
                return;
            }

            var existingVideo = await _materialManageService.GetVideoByName(name);
            if (existingVideo == null)
            {
                Console.WriteLine($"{EntityName.VIDEO} {Result.DOES_NOT_EXIST}, {Operation.DELETING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }
            else
            {
                await _materialManageService.DeleteVideo(name);
            }
        }

        private async Task UpdateVideo()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.VIDEO))
            {
                return;
            }

            var existingVideo = await _materialManageService.GetVideoByName(name);
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

            existingVideo.Name = newName;
            existingVideo.Duration = duration;
            existingVideo.Quality = quality;

            await _materialManageService.UpdateVideo(existingVideo);
        }

        private async Task AddArticle()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.ARTICLE))
            {
                return;
            }

            var existingArticle = await _materialManageService.GetArticleByName(name);
            if (existingArticle != null)
            {
                Console.WriteLine($"{EntityName.ARTICLE} {Result.ALREADY_EXISTS}, {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
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
            await _materialManageService.SetArticle(articleMaterial);
        }

        private async Task DeleteArticle()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.ARTICLE))
            {
                return;
            }

            var existingArticle = await _materialManageService.GetArticleByName(name);
            if (existingArticle == null)
            {
                Console.WriteLine($"{EntityName.ARTICLE} {Result.DOES_NOT_EXIST}, {Operation.DELETING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }
            else
            {
                await _materialManageService.DeleteArticle(name);
            }
        }

        private async Task UpdateArticle()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.ARTICLE))
            {
                return;
            }

            var existingArticle = await _materialManageService.GetArticleByName(name);
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

            existingArticle.Name = newName;
            existingArticle.Source = source;
            existingArticle.PublicationDate = publicationDate;

            await _materialManageService.UpdateArticle(existingArticle);
        }
    }
}
