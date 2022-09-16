using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EducationPortal.UI.Controllers
{
    [Authorize]
    public class EditingMaterialsController : Controller
    {
        private readonly IMaterialEditService _materialService;

        public EditingMaterialsController(IMaterialEditService materialService)
        {
            _materialService = materialService;
        }

        public async Task<IActionResult> Materials()
        {
            var materials = await _materialService.GetMaterials();
            return View(materials);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(MaterialView material)
        {
            if (ModelState.IsValid)
            {
                if (material.Id == 0)
                {
                    await _materialService.SetMaterial(material);
                }

                return RedirectToAction("Materials");
            }

            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (ModelState.IsValid)
            {
                MaterialView? material = await _materialService.GetByIdMaterial(id ?? 0);
                if (material != null)
                {
                    return View(material);
                }

                return NotFound();
            }

            return View(id);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(MaterialView material)
        {
            await _materialService.UpdateMaterial(material);

            return RedirectToAction("Materials");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int? id)
        {
            MaterialView? material = await _materialService.GetByIdMaterial(id ?? 0);
            if (material != null)
            {
                _materialService.RemoveMaterial(material);
                return RedirectToAction("Materials");
            }

            return NotFound();
        }
    }
}
