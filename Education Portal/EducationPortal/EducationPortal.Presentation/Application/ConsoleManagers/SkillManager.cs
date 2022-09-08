using EducationPortal.Domain.Entities;

namespace EducationPortal.Presentation.Application
{
    internal class SkillManager
    {
        private readonly ISkillService _skillService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public SkillManager(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public void EditSkills()
        {
            while (true)
            {
                Console.Clear();
                OutputSkills();

                Console.WriteLine(MenuStrings.SKILL_MENU);

                string input = Console.ReadLine() ?? "";
                switch (input)
                {
                    case "quit":
                        return;
                    case "1":
                        AddSkill();
                        break;
                    case "2":
                        DeleteSkill();
                        break;
                    case "3":
                        UpdateSkill();
                        break;
                    default:
                        Console.WriteLine(Result.WRONG_COMMAND);
                        Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                        break;
                }
            }
        }

        private void OutputSkills()
        {
            Console.WriteLine("All skills:");
            var skills = _skillService.GetSkills();
            foreach (var skill in skills)
            {
                Console.WriteLine($"Title: {skill.Title}");
                Console.WriteLine("---<>---");
            }
        }

        private void AddSkill()
        {
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", Operation.ADDING, EntityName.SKILL))
            {
                return;
            }

            var existingSkill = _skillService.GetSkillByTitle(title);
            if (existingSkill != null)
            {
                Console.WriteLine($"{EntityName.SKILL} {Result.ALREADY_EXISTS}, {Operation.ADDING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            Skill skill = new Skill
            {
                Title = title
            };
            _skillService.SetSkill(skill);
        }

        private void DeleteSkill()
        {
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", Operation.DELETING, EntityName.SKILL))
            {
                return;
            }

            var existingSkill = _skillService.GetSkillByTitle(title);
            if (existingSkill == null)
            {
                Console.WriteLine($"{EntityName.SKILL} {Result.DOES_NOT_EXIST}, {Operation.DELETING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }
            else
            {
                _skillService.DeleteSkill(title);
            }
        }

        private void UpdateSkill()
        {
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", Operation.UPDATING, EntityName.SKILL))
            {
                return;
            }

            var existingSkill = _skillService.GetSkillByTitle(title);
            if (existingSkill == null)
            {
                Console.WriteLine($"{EntityName.SKILL} {Result.DOES_NOT_EXIST}, {Operation.UPDATING} {Result.INTERRUPTED}");
                Thread.Sleep(Result.WRONG_COMMAND_DELAY);
                return;
            }

            string newTitle;
            if (!_inputHandler.TryInputStringValue(out newTitle, "new title", Operation.UPDATING, EntityName.SKILL))
            {
                return;
            }

            Skill skill = new Skill
            {
                Title = newTitle
            };
            _skillService.UpdateSkill(existingSkill, skill);
        }
    }
}