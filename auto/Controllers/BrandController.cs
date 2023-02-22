using auto.Domain.Entities;
using auto.Domain.Repositories.Abstract;
using auto.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace auto.Controllers
{
    [Authorize]
    public class BrandController : Controller
    {
        private readonly IBrandRepository _brandRepository;

        public BrandController(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<Brand> AllBrand = await _brandRepository.GetAll();
            ViewData["Brands"] = AllBrand;

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddBrand(Brand model)
        {
            if (await _brandRepository.Create(model))
            {
                return RedirectToAction("Index", "Brand");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBrand(int id)
        {
            if (await _brandRepository.Delete(id))
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }
        }

        [HttpGet]
        public async Task<IActionResult> UpdateBrand(int id)
        {
            if (id!=null)
            {
                Brand brand = await _brandRepository.GetById(id);
                return View(brand);
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> UpdateBrand(int id, Brand model)
        {
            if (await _brandRepository.Update(model, id))
            {
                return RedirectToAction("Index", "Brand");
            }
            else
            {
                return NotFound();
            }
        }
    }
}
