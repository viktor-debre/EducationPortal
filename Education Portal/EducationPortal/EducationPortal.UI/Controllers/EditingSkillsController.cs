using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    public class EditingSkillsController : Controller
    {
        private readonly ISkillEditService _skillEditService;

        public EditingSkillsController(ISkillEditService skillEditService)
        {
            _skillEditService = skillEditService;
        }

        public IActionResult Skills()
        {
            var skills = _skillEditService.GetSkills();
            return View(skills);
        }
    }
}
