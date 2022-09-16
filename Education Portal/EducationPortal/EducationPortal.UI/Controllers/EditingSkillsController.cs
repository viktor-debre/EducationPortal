using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class EditingSkillsController : Controller
    {
        private readonly ISkillEditService _skillEditService;

        public EditingSkillsController(ISkillEditService skillEditService)
        {
            _skillEditService = skillEditService;
        }

        public async Task<IActionResult> Skills()
        {
            var skills = await _skillEditService.GetSkills();
            return View(skills);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(SkillView skill)
        {
            if (ModelState.IsValid)
            {
                if (skill.Id == 0)
                {
                    await _skillEditService.SetSkill(skill);
                }

                return RedirectToAction("Skills");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (ModelState.IsValid)
            {
                SkillView? skill = await _skillEditService.GetByIdSkill(id ?? 0);
                if (skill != null)
                {
                    return View(skill);
                }

                return NotFound();
            }

            return View(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SkillView skill)
        {
            await _skillEditService.UpdateSkill(skill);

            return RedirectToAction("Skills");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            SkillView? skill = await _skillEditService.GetByIdSkill(id ?? 0);
            if (skill != null)
            {
                _skillEditService.RemoveSkill(skill);
                return RedirectToAction("Skills");
            }

            return NotFound();
        }
    }
}
