﻿using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleMaterialManager
    {
        private const int WrongCommandDelay = 1500;
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
                        break;
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
            Console.WriteLine("Input name of book: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name adding book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input author name of book: ");
            var author = Console.ReadLine();
            if (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Wrong author name adding book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input format of book: ");
            var format = Console.ReadLine();
            if (string.IsNullOrEmpty(format))
            {
                Console.WriteLine("Wrong format adding book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input number of pages of book: ");
            var numberOfPagesString = Console.ReadLine();
            int numberOfPages;
            if (!int.TryParse(numberOfPagesString, out numberOfPages))
            {
                Console.WriteLine("Wrong number of pages book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input publication date time of book: ");
            var publicationDateString = Console.ReadLine();
            DateTime publicationDate;
            if (!DateTime.TryParse(publicationDateString, out publicationDate))
            {
                Console.WriteLine("Wrong number of pages book interrupted!");
                Thread.Sleep(WrongCommandDelay);
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
            Console.WriteLine("Input name of book to delete: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name deleting book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }
            else
            {
                _materialManageService.DeleteBook(name);
            }
        }

        private void UpdateBook()
        {
            Console.WriteLine("Input name of book you want to update: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name updating book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input new name of book: ");
            var newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Wrong name adding book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input new author name of book: ");
            var author = Console.ReadLine();
            if (string.IsNullOrEmpty(author))
            {
                Console.WriteLine("Wrong author name adding book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input new format of book: ");
            var format = Console.ReadLine();
            if (string.IsNullOrEmpty(format))
            {
                Console.WriteLine("Wrong format adding book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input new number of pages of book: ");
            var numberOfPagesString = Console.ReadLine();
            int numberOfPages;
            if (!int.TryParse(numberOfPagesString, out numberOfPages))
            {
                Console.WriteLine("Wrong number of pages book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input new publication date time of book: ");
            var publicationDateString = Console.ReadLine();
            DateTime publicationDate;
            if (!DateTime.TryParse(publicationDateString, out publicationDate))
            {
                Console.WriteLine("Wrong number of pages book interrupted!");
                Thread.Sleep(WrongCommandDelay);
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
            Console.WriteLine("Input name of video: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name adding video interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input quality of video: ");
            var quality = Console.ReadLine();
            if (string.IsNullOrEmpty(quality))
            {
                Console.WriteLine("Wrong quality adding video interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input duration of video: ");
            var durationString = Console.ReadLine();
            TimeSpan duration;
            if (!TimeSpan.TryParse(durationString, out duration))
            {
                Console.WriteLine("Wrong duration video interrupted!");
                Thread.Sleep(WrongCommandDelay);
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
            Console.WriteLine("Input name of video to delete: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name deleting video interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }
            else
            {
                _materialManageService.DeleteVideo(name);
            }
        }

        private void UpdateVideo()
        {
            Console.WriteLine("Input name of video you want to update: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name updating video interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input name of video: ");
            var newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Wrong name adding video interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input quality of video: ");
            var quality = Console.ReadLine();
            if (string.IsNullOrEmpty(quality))
            {
                Console.WriteLine("Wrong quality adding video interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input duration of video: ");
            var durationString = Console.ReadLine();
            TimeSpan duration;
            if (!TimeSpan.TryParse(durationString, out duration))
            {
                Console.WriteLine("Wrong duration video interrupted!");
                Thread.Sleep(WrongCommandDelay);
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
            Console.WriteLine("Input name of article: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name adding article interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input source of article: ");
            var source = Console.ReadLine();
            if (string.IsNullOrEmpty(source))
            {
                Console.WriteLine("Wrong source adding article interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input duration of article: ");
            var publicationDateString = Console.ReadLine();
            DateTime publicationDate;
            if (!DateTime.TryParse(publicationDateString, out publicationDate))
            {
                Console.WriteLine("Wrong number of pages article interrupted!");
                Thread.Sleep(WrongCommandDelay);
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
            Console.WriteLine("Input name of book to delete: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name deleting book interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }
            else
            {
                _materialManageService.DeleteBook(name);
            }
        }

        private void UpdateArticle()
        {
            Console.WriteLine("Input name of article you want to update: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name updating article interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input name of article: ");
            var newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Wrong name adding article interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input source of article: ");
            var source = Console.ReadLine();
            if (string.IsNullOrEmpty(source))
            {
                Console.WriteLine("Wrong source adding article interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input duration of article: ");
            var publicationDateString = Console.ReadLine();
            DateTime publicationDate;
            if (!DateTime.TryParse(publicationDateString, out publicationDate))
            {
                Console.WriteLine("Wrong number of pages article interrupted!");
                Thread.Sleep(WrongCommandDelay);
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
