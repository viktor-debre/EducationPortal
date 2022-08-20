using EducationPortal.Domain.Entities;

namespace EducationPortal.Presentation.Application
{
    internal class ConsoleSkillManager
    {
        private readonly ISkillService _skillService;
        private readonly InputHandler _inputHandler = new InputHandler();

        public ConsoleSkillManager(ISkillService skillService)
        {
            _skillService = skillService;
        }

        public void EditSkills()
        {
            while (true)
            {
                Console.Clear();
                OutputSkills();

                Console.WriteLine(MenuConstants.SKILL_MENU);
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
                        Console.WriteLine("Unknown command");
                        Thread.Sleep(MenuConstants.WRONG_COMMAND_DELAY);
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
            }
        }

        private void AddSkill()
        {
            string operation = "adding skill";
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", operation))
            {
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
            string operation = "deleting skill";
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", operation))
            {
                return;
            }
            else
            {
                _skillService.DeleteSkill(title);
            }
        }

        private void UpdateSkill()
        {
            string operation = "update skill";
            string title;
            if (!_inputHandler.TryInputStringValue(out title, "title", operation))
            {
                return;
            }

            string newTitle;
            if (!_inputHandler.TryInputStringValue(out newTitle, "new title", operation))
            {
                return;
            }

            Skill skill = new Skill
            {
                Title = newTitle
            };
            _skillService.UpdateSkill(title, skill);
        }
    }
}