using EducationPortal.Domain.Entities;

namespace EducationPortal.Presentation.Application
{
    internal class CourseManager
    {
        private readonly ICourseService _courseService;
        private readonly IMaterialManageService _materialManageService;
        private readonly ISkillService _skillService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public CourseManager(ICourseService courseService,
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

                Console.WriteLine(MenuStrings.COURSE_MENU);
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
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void OutputCourses()
        {
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
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.COURSE))
            {
                return;
            }

            string description;
            if (!_inputHandler.TryInputStringValue(out description, "description", Operation.ADDING, EntityName.COURSE))
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
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.COURSE))
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
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.COURSE))
            {
                return;
            }

            var existingCourse = _courseService.GetCourses().FirstOrDefault(x => x.Name == name);
            if (existingCourse == null)
            {
                Console.WriteLine($"{EntityName.COURSE} {Result.DOES_NOT_EXIST}, {Operation.UPDATING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            string newName;
            if (!_inputHandler.TryInputStringValue(out newName, "new name", Operation.UPDATING, EntityName.COURSE))
            {
                return;
            }

            string description;
            if (!_inputHandler.TryInputStringValue(out description, "description", Operation.UPDATING, EntityName.COURSE))
            {
                return;
            }

            List<Material> mateirals = existingCourse.Materials;
            ChangeMaterials(mateirals);

            List<Skill> skills = existingCourse.Skills;
            ChangeSkills(skills);
            Course course = new Course
            {
                Name = newName,
                Description = description,
                Materials = mateirals,
                Skills = skills
            };
            _courseService.UpdateCourse(existingCourse, course);
        }

        private List<Material> AllMaterials()
        {
            List<BookMaterial> bookMaterials = _materialManageService.GetBooks();
            List<VideoMaterial> videoMaterials = _materialManageService.GetVideos();
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
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.COURSE_MATERIAL))
            {
                return;
            }

            var material = allMaterials.FirstOrDefault(x => x.Name == name);
            if (material == null)
            {
                Console.WriteLine($"{EntityName.MATERIAL} {Result.DOES_NOT_EXIST} {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            var inList = materials.Find(x => x.Id == material.Id);
            if (inList != null)
            {
                Console.WriteLine($"{EntityName.MATERIAL} {Result.ALREADY_IN_LIST} {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            materials.Add(material);
        }

        private void DeleteMaterialInCourse(List<Material> materials)
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.COURSE_MATERIAL))
            {
                return;
            }

            var material = materials.FirstOrDefault(x => x.Name == name);
            if (!materials.Remove(material))
            {
                Console.WriteLine($"{EntityName.MATERIAL} {Result.DOES_NOT_EXIST} {Operation.DELETING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }
        }

        private void ChangeMaterials(List<Material> materials)
        {
            Console.Clear();
            OutputAllMaterials();
            while (true)
            {
                Console.WriteLine(MenuStrings.COURSE_MATERIAL_MENU);

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
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void ChangeSkills(List<Skill> skills)
        {
            Console.Clear();
            OutputAllSkills();
            while (true)
            {
                Console.WriteLine(MenuStrings.COURSE_SKILL_MENU);
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
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void AddSkillInCourse(List<Skill> skills)
        {
            var allSkills = AllSkills();
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", Operation.ADDING, EntityName.COURSE_SKILL))
            {
                return;
            }

            var skill = allSkills.FirstOrDefault(x => x.Title == title);
            if (skill == null)
            {
                Console.WriteLine($"{EntityName.SKILL} {Result.DOES_NOT_EXIST} {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            var inList = skills.Find(x => x.Id == skill.Id);
            if (inList != null)
            {
                Console.WriteLine($"{EntityName.SKILL} {Result.ALREADY_IN_LIST} {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            skills.Add(skill);
        }

        private void DeleteSkillInCourse(List<Skill> skills)
        {
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", Operation.DELETING, EntityName.COURSE_SKILL))
            {
                return;
            }

            var skill = skills.FirstOrDefault(x => x.Title == title);
            if (!skills.Remove(skill))
            {
                Console.WriteLine($"{EntityName.SKILL} {Result.DOES_NOT_EXIST} {Operation.DELETING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }
        }
    }
}