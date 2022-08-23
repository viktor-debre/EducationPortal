using EducationPortal.Domain.Entities;
using EducationPortal.Domain.Entities.Materials;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleCourseManager
    {
        private readonly ICourseService _courseService;
        private readonly IMaterialManageService _materialManageService;
        private readonly ISkillService _skillService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public ConsoleCourseManager(ICourseService courseService,
                                    IMaterialManageService materialManageService,
                                    ISkillService skillService)
        {
            _courseService = courseService;
            _materialManageService = materialManageService;
            _skillService = skillService;
        }

        public void EditCources()
        {
            while (true)
            {
                Console.Clear();
                OutputCourses();

                Console.WriteLine(MenuConstants.COURSE_MENU);
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
                        Console.WriteLine(MenuConstants.WRONG_COMMAND);
                        Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void OutputCourses()
        {
            OutputAllMaterials();
            OutputAllSkills();
            OutputAllCoursesFromStorage();
        }

        private void OutputAllCoursesFromStorage()
        {
            Console.WriteLine("Courses:");
            List<Course> courses = _courseService.GetCourses();
            int courseNumber = 1;
            foreach (Course course in courses)
            {
                Console.WriteLine($"--<{courseNumber}>--");
                Console.WriteLine($"{course.Name}\nDescription: {course.Description}\nMaterials:");
                int materialNumber = 1;
                foreach (Material material in course.Materials)
                {
                    Console.WriteLine($"{materialNumber} name: {material.Name}");
                    materialNumber++;
                }

                Console.WriteLine("Skills:");
                int skillNumber = 1;
                foreach (Skill skill in course.Skills)
                {
                    Console.WriteLine($"{skillNumber} title: {skill.Title}");
                    skillNumber++;
                }

                courseNumber++;
            }
        }

        private void OutputAllMaterials()
        {
            Console.WriteLine("All materials:");
            var allMaterials = AllMaterials();
            foreach (Material material in allMaterials)
            {
                Console.WriteLine($"Name: {material.Name}");
            }
        }

        private void OutputAllSkills()
        {
            Console.WriteLine("All skills:");
            List<Skill> skills = AllSkills();
            foreach (var skill in skills)
            {
                Console.WriteLine($"Title: {skill.Title}");
            }
        }

        private List<Skill> AllSkills()
        {
            return _skillService.GetSkills();
        }

        private void AddCourse()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING + Operation.COURSE))
            {
                return;
            }

            string description;
            if (!_inputHandler.TryInputStringValue(out description, "description", Operation.ADDING + Operation.COURSE))
            {
                return;
            }

            List<Material> mateirals = new List<Material>();
            ChangeMaterials(mateirals);
            List<Skill> skills = new List<Skill>();
            ChangeSkills(skills);

            Course course = new Course
            {
                Name = name,
                Description = description,
                Materials = mateirals,
                Skills = skills
            };
            _courseService.SetCourse(course);
        }

        private void DeleteCourse()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING + Operation.COURSE))
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
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING + Operation.COURSE))
            {
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "new name", Operation.UPDATING + Operation.COURSE))
            {
                return;
            }

            string description;
            if (!_inputHandler.TryInputStringValue(out description, "description", Operation.UPDATING + Operation.COURSE))
            {
                return;
            }

            List<Material> mateirals = new List<Material>();
            ChangeMaterials(mateirals);

            List<Skill> skills = new List<Skill>();
            ChangeSkills(skills);
            Course course = new Course
            {
                Name = newName,
                Description = description,
                Materials = mateirals,
                Skills = skills
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
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING + Operation.MATERIAL + Operation.IN_COURSE))
            {
                return;
            }

            var material = allMaterials.FirstOrDefault(x => x.Name == name);
            if (material == null)
            {
                Console.WriteLine("Material does not exist, adding material in course interrupted!");
                Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
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
                Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
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
                        Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void ChangeSkills(List<Skill> skills)
        {
            while (true)
            {
                Console.WriteLine("Input 'add' - add skill or " +
                    "'del' - to delete skill or " +
                    "'stop' - to stop modifing");
                var input = Console.ReadLine();

                switch (input)
                {
                    case "stop":
                        return;
                    case "add":
                        AddSkillInCourse(skills);
                        break;
                    case "del":
                        DeleteSkillInCourse(skills);
                        break;
                    default:
                        Console.WriteLine("Unknown command");
                        Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void DeleteSkillInCourse(List<Skill> skills)
        {
            string operation = "deleting material in course";
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", operation))
            {
                return;
            }

            var skill = skills.FirstOrDefault(x => x.Title == title);
            if (!skills.Remove(skill))
            {
                Console.WriteLine($"Skill to delete not finded, {operation} interrupted!");
                Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                return;
            }
        }

        private void AddSkillInCourse(List<Skill> skills)
        {
            string operation = "adding skill in course";
            var allSkills = AllSkills();
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", operation))
            {
                return;
            }

            var skill = allSkills.FirstOrDefault(x => x.Title == title);
            if (skill == null)
            {
                Console.WriteLine($"Skill does not exist, {operation} interrupted!");
                Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
                return;
            }

            skills.Add(skill);
        }
    }
}