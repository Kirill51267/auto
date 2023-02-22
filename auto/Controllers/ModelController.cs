using auto.Domain.Entities;
using auto.Domain.Repositories.Abstract;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auto.Controllers
{
    [Authorize]
    public class ModelController : Controller
    {
        private readonly IModelRepository _modelRepository;

        public ModelController(IModelRepository modelRepository)
        {
            _modelRepository = modelRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            List<Model> responce = await _modelRepository.GetAllByBrandId(id);
            ViewData["Models"] = responce;
            ViewData["BrandId"] = id;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Model> responce = await _modelRepository.GetAll();
            ViewData["Models"] = responce;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteModel(int id, int brandId)
        {
            if (await _modelRepository.Delete(id))
            {
                return RedirectToAction("Index", "Model", new { id = brandId });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddModel(Model model, int brandId)
        {
            if (await _modelRepository.Create(model, brandId))
            {
                return RedirectToAction("Index", "Model", new { id = brandId });
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateModel(int id, int brandId)
        {
            if (id != null)
            {
                Model model = await _modelRepository.GetById(id);
                ViewData["BrandId"] = brandId;
                return View(model);
            }
            return NotFound();
        }


        [HttpPost]
        public async Task<IActionResult> UpdateModel(Model model, int id, int brandId)
        {
            if (await _modelRepository.Update(model, id))
            {
                return RedirectToAction("Index", "Model", new { id = brandId });
            }
            else
            {
                return NotFound();
            }
        }
    }
}
