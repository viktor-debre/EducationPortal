namespace EducationPortal.Presentation.Application
{
    internal class CourseManager
    {
        private readonly ICourseService _courseService;
        private readonly IMaterialManageService _materialManageService;
        private readonly ISkillService _skillService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public CourseManager(
            ICourseService courseService,
            IMaterialManageService materialManageService,
            ISkillService skillService
        )
        {
            _courseService = courseService;
            _materialManageService = materialManageService;
            _skillService = skillService;
        }

        public async Task EditCources()
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
                        await AddCourse();
                        break;
                    case "2":
                        await DeleteCourse();
                        break;
                    case "3":
                        await UpdateCourse();
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private async Task OutputCourses()
        {
            await OutputAllCoursesFromStorage();
        }

        private async Task OutputAllCoursesFromStorage()
        {
            Console.WriteLine("Courses:");
            List<Course> courses = await _courseService.GetCourses();
            int courseNumber = 1;
            foreach (Course course in courses)
            {
                Console.WriteLine($"--<{courseNumber}>--");
                Console.WriteLine($"{course.Name}\nDescription: {course.Description}\nMaterials:");
                int materialNumber = 1;
                if (course.Materials != null)
                {
                    foreach (Material material in course.Materials)
                    {
                        Console.WriteLine($"{materialNumber} name: {material.Name}");
                        materialNumber++;
                    }
                }

                Console.WriteLine("Skills:");
                int skillNumber = 1;
                if (course.Skills != null)
                {
                    foreach (Skill skill in course.Skills)
                    {
                        Console.WriteLine($"{skillNumber} title: {skill.Title}");
                        skillNumber++;
                    }
                }

                courseNumber++;
            }
        }

        private async Task OutputAllMaterials()
        {
            Console.WriteLine("All materials:");
            var allMaterials = await AllMaterials();
            foreach (Material material in allMaterials)
            {
                Console.WriteLine($"Name: {material.Name}");
            }
        }

        private async Task OutputAllSkills()
        {
            Console.WriteLine("All skills:");
            List<Skill> skills = await AllSkills();
            foreach (var skill in skills)
            {
                Console.WriteLine($"Title: {skill.Title}");
            }
        }

        private async Task<List<Skill>> AllSkills()
        {
            return await _skillService.GetSkills();
        }

        private async Task AddCourse()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.ADDING, EntityName.COURSE))
            {
                return;
            }

            var existingCourse = await _courseService.GetCourseByName(name);
            if (existingCourse != null)
            {
                Console.WriteLine($"{EntityName.COURSE} {Result.ALREADY_EXISTS}, {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
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
            await _courseService.SetCourse(course);
        }

        private async Task DeleteCourse()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.DELETING, EntityName.COURSE))
            {
                return;
            }

            var existingCourse = await _courseService.GetCourseByName(name);
            if (existingCourse == null)
            {
                Console.WriteLine($"{EntityName.COURSE} {Result.DOES_NOT_EXIST}, {Operation.DELETING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }
            else
            {
                await _courseService.DeleteCourse(name);
            }
        }

        private async Task UpdateCourse()
        {
            string name;
            if (!_inputHandler.TryInputStringValue(out name, "name", Operation.UPDATING, EntityName.COURSE))
            {
                return;
            }

            var existingCourse = await _courseService.GetCourseByName(name);
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
            await _courseService.UpdateCourse(existingCourse, course);
        }

        private async Task<List<Material>> AllMaterials()
        {
            List<BookMaterial> bookMaterials = await _materialManageService.GetBooks();
            List<VideoMaterial> videoMaterials = await _materialManageService.GetVideos();
            List<ArticleMaterial> articleMaterials = await _materialManageService.GetArticles();

            List<Material> materials = new List<Material>();
            materials.AddRange(bookMaterials);
            materials.AddRange(videoMaterials);
            materials.AddRange(articleMaterials);

            return materials;
        }

        private async Task AddMaterialInCourse(List<Material> materials)
        {
            var allMaterials = await AllMaterials();
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

        private async Task DeleteMaterialInCourse(List<Material> materials)
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

        private async Task ChangeMaterials(List<Material> materials)
        {
            Console.Clear();
            await OutputAllMaterials();
            while (true)
            {
                Console.WriteLine(MenuStrings.COURSE_MATERIAL_MENU);

                var input = Console.ReadLine();
                switch (input)
                {
                    case "stop":
                        return;
                    case "add":
                        await AddMaterialInCourse(materials);
                        break;
                    case "del":
                        await DeleteMaterialInCourse(materials);
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private async Task ChangeSkills(List<Skill> skills)
        {
            Console.Clear();
            await OutputAllSkills();
            while (true)
            {
                Console.WriteLine(MenuStrings.COURSE_SKILL_MENU);
                var input = Console.ReadLine();

                switch (input)
                {
                    case "stop":
                        return;
                    case "add":
                        await AddSkillInCourse(skills);
                        break;
                    case "del":
                        await DeleteSkillInCourse(skills);
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private async Task AddSkillInCourse(List<Skill> skills)
        {
            var allSkills = await AllSkills();
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

        private async Task DeleteSkillInCourse(List<Skill> skills)
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