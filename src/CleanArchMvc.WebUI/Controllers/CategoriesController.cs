using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CleanArchMvc.WebUI.Controllers
{
    public class CategoriesController : Controller
    {
        private readonly ICategoryService _categoryService;
        public CategoriesController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var categoriesDto = await _categoryService.GetCategories();

            return View(categoriesDto.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                await _categoryService.Add(categoryDto);
                return RedirectToAction(nameof(Index));
            }
                
            return View(categoryDto);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
                 return View("Error");

            var categoryDto = await _categoryService.GetById(id);

            if (categoryDto == null)
                return View("Error");

            return View(categoryDto);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CategoryDto categoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _categoryService.Update(categoryDto);
                    
                }
                catch (Exception)
                {

                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
                
            return View(categoryDto);
        }
    }
}