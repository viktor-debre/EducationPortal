using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleCourseManager
    {
        private const int WrongCommandDelay = 1500;
        private readonly ICourseService _courseService;
        private readonly IMaterialManageService _materialManageService;
        private readonly InputHandler _inputHandler = new InputHandler();

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
                OutputCourses();

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
                        AddCourse();
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

        private void OutputCourses()
        {
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
        }

        private void AddCourse()
        {
            string operation = "adding course";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            string description;
            if (!_inputHandler.TryInputStringValue(out description, "description", operation))
            {
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
            string operation = "deleting course";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }
            else
            {
                _courseService.DeleteCourse(name);
            }
        }

        private void UpdateCourse()
        {
            string operation = "updating course";
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

            string description;
            if (!_inputHandler.TryInputStringValue(out description, "name", operation))
            {
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

        private void AddMaterialInCourse(List<Material> materials)
        {
            var allMaterials = AllMaterials();
            string operation = "adding material in course";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            var material = allMaterials.FirstOrDefault(x => x.Name == name);
            if (material == null)
            {
                Console.WriteLine("Material does not exist, adding material in course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }

            materials.Add(material);
        }

        private void DeleteMaterialInCourse(List<Material> materials)
        {
            string operation = "deleting material in course";
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", operation))
            {
                return;
            }

            var material = materials.FirstOrDefault(x => x.Name == name);
            if (!materials.Remove(material))
            {
                Console.WriteLine("Material to delete not finded, deleting material in course interrupted!");
                Thread.Sleep(WrongCommandDelay);
                return;
            }
        }

        private void ChangeMaterials(List<Material> materials)
        {
            while (true)
            {
                Console.WriteLine("Input 'add' - add material or " +
                    "'del' - to delete material or " +
                    "'stop' - to stop modifing");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "stop":
                        return;
                    case "add":
                        AddMaterialInCourse(materials);
                        break;
                    case "del":
                        DeleteMaterialInCourse(materials);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        Thread.Sleep(WrongCommandDelay);
                        break;
                }
            }
        }
    }
}