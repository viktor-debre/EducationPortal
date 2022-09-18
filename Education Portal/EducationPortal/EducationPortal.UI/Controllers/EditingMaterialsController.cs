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

        public IActionResult CreateArticle()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateArticle(ArticleView material)
        {
            if (ModelState.IsValid)
            {
                if (material.Id == 0)
                {
                    await _materialService.SetArticle(material);
                }

                return RedirectToAction("Materials");
            }

            return View();
        }

        public IActionResult CreateBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBook(BookView material)
        {
            if (ModelState.IsValid)
            {
                if (material.Id == 0)
                {
                    await _materialService.SetBook(material);
                }

                return RedirectToAction("Materials");
            }

            return View();
        }

        public IActionResult CreateVideo()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateVideo(VideoView material)
        {
            if (ModelState.IsValid)
            {
                if (material.Id == 0)
                {
                    await _materialService.SetVideo(material);
                }

                return RedirectToAction("Materials");
            }

            return View();
        }

        public async Task<IActionResult> EditArticle(int? id)
        {
            if (ModelState.IsValid)
            {
                ArticleView? material = await _materialService.GetByIdArticle(id ?? 0);
                if (material != null)
                {
                    return View(material);
                }

                return NotFound();
            }

            return View(id);
        }

        public async Task<IActionResult> EditBook(int? id)
        {
            if (ModelState.IsValid)
            {
                BookView? material = await _materialService.GetByIdBook(id ?? 0);
                if (material != null)
                {
                    return View(material);
                }

                return NotFound();
            }

            return View(id);
        }

        public async Task<IActionResult> EditVideo(int? id)
        {
            if (ModelState.IsValid)
            {
                VideoView? material = await _materialService.GetByIdVideo(id ?? 0);
                if (material != null)
                {
                    return View(material);
                }

                return NotFound();
            }

            return View(id);
        }

        [HttpPost]
        public async Task<IActionResult> EditArticle(ArticleView material)
        {
            await _materialService.UpdateArticle(material);

            return RedirectToAction("Materials");
        }

        [HttpPost]
        public async Task<IActionResult> EditBook(BookView material)
        {
            await _materialService.UpdateBook(material);

            return RedirectToAction("Materials");
        }

        [HttpPost]
        public async Task<IActionResult> EditVideo(VideoView material)
        {
            await _materialService.UpdateVideo(material);

            return RedirectToAction("Materials");
        }

        public async Task<IActionResult> DeleteArticle(int? id)
        {
            ArticleView? material = await _materialService.GetByIdArticle(id ?? 0);
            if (material != null)
            {
                _materialService.RemoveArticle(material);
                return RedirectToAction("Materials");
            }

            return NotFound();
        }

        public async Task<IActionResult> DeleteBook(int? id)
        {
            BookView? material = await _materialService.GetByIdBook(id ?? 0);
            if (material != null)
            {
                _materialService.RemoveBook(material);
                return RedirectToAction("Materials");
            }

            return NotFound();
        }

        public async Task<IActionResult> DeleteVideo(int? id)
        {
            VideoView? material = await _materialService.GetByIdVideo(id ?? 0);
            if (material != null)
            {
                _materialService.RemoveVideo(material);
                return RedirectToAction("Materials");
            }

            return NotFound();
        }
    }
}
