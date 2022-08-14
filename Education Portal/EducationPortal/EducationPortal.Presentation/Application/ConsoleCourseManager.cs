using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleCourseManager
    {
        private const int WrongCommandDelay = 1500;
        private readonly ICourseService _courseService;
        private readonly IMaterialManageService _materialManageService;

        public ConsoleCourseManager(ICourseService courseService, IMaterialManageService materialManageService)
        {
            _courseService = courseService;
            _materialManageService = materialManageService;
        }

        public void EditCources()
        {
            while (true)
            {
                Console.Clear();

                Console.WriteLine("All materials:");
                var allMaterials = AllMaterials();
                foreach (Material material in allMaterials)
                {
                    Console.WriteLine($"Name: {material.Name}");
                }

                Console.WriteLine("Courses:");
                List<Course> courses = _courseService.GetCourses();

                foreach (Course course in courses)
                {
                    Console.WriteLine("////////Other course//////////");
                    Console.WriteLine($"{course.Name}\nDescription: {course.Description}\nMaterials:");
                    foreach (Material material in course.Matherials)
                    {
                        Console.WriteLine($"Material name: {material.Name}");
                    }
                }

                Console.WriteLine("Editing material menu:\n" +
                   "1 - add course\n" +
                   "2 - delete course\n" +
                   "3 - update course\n" +
                   "quit - go to previous menu");
                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    case "1":
                        CreateCourse();
                        break;
                    case "2":
                        DeleteCourse();
                        break;
                    case "3":
                        UpdateCourse();
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        Thread.Sleep(WrongCommandDelay);
                        break;
                }
            }
        }

        private void CreateCourse()
        {
            Console.WriteLine("Input name of course:");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name adding course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input description of course:");
            var description = Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Wrong description adding course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            List<Material> mateirals = new List<Material>();
            ChangeMaterials(mateirals);
            Course course = new Course
            {
                Name = name,
                Description = description,
                Matherials = mateirals
            };
            _courseService.SetCourse(course);
        }

        private void DeleteCourse()
        {
            Console.WriteLine("Input name of course to delete: ");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Empty name field deleting course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }
            else
            {
                _courseService.DeleteCourse(name);
            }
        }

        private void UpdateCourse()
        {
            Console.WriteLine("Input name of course you want to change:");
            var name = Console.ReadLine();
            if (string.IsNullOrEmpty(name))
            {
                Console.WriteLine("Wrong name adding course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input name of course:");
            var newName = Console.ReadLine();
            if (string.IsNullOrEmpty(newName))
            {
                Console.WriteLine("Wrong name adding course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            Console.WriteLine("Input description of course:");
            var description = Console.ReadLine();
            if (string.IsNullOrEmpty(description))
            {
                Console.WriteLine("Wrong description adding course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            List<Material> mateirals = new List<Material>();
            ChangeMaterials(mateirals);
            Course course = new Course
            {
                Name = newName,
                Description = description,
                Matherials = mateirals
            };
            _courseService.UpdateCourse(name, course);
        }

        private List<Material> AllMaterials()
        {
            List<BookMaterial> bookMaterials = _materialManageService.GetBooks();
            List<VideoMaterial> videoMaterials = _materialManageService.GetVideo();
            List<ArticleMaterial> articleMaterials = _materialManageService.GetArticle();

            List<Material> materials = new List<Material>();
            materials.AddRange(bookMaterials);
            materials.AddRange(videoMaterials);
            materials.AddRange(articleMaterials);

            return materials;
        }

        private void ChangeMaterials(List<Material> materials)
        {
            while (true)
            {
                var allMaterials = AllMaterials();
                Console.WriteLine("Input 'add' - add material or 'del' - to delete material or 'stop' - to stop modifing");
                var input = Console.ReadLine();
                if (input == "stop")
                {
                    return;
                }

                if (input == "add")
                {
                    Console.WriteLine("Input name of material you want to add:");
                    var name = Console.ReadLine();
                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Empty name, adding material in course interrupted!");
                        Thread.Sleep(WrongCommandDelay);
                        continue;
                    }

                    var material = allMaterials.FirstOrDefault(x => x.Name == name);
                    if (material == null)
                    {
                        Console.WriteLine("Material does not exist, adding material in course interrupted!");
                        Thread.Sleep(WrongCommandDelay);
                        continue;
                    }

                    materials.Add(material);
                    continue;
                }

                if (input == "del")
                {
                    Console.WriteLine("Input name of material you want to delete:");
                    var name = Console.ReadLine();

                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Empty name, deleting material in course interrupted!");
                        Thread.Sleep(WrongCommandDelay);
                        continue;
                    }

                    var material = materials.FirstOrDefault(x => x.Name == name);
                    if (!materials.Remove(material))
                    {
                        Console.WriteLine("Material to delete not finded");
                        continue;
                    }

                    continue;
                }
            }
        }
    }
}