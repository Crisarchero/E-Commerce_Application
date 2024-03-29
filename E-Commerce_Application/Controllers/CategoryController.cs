﻿using Microsoft.AspNetCore.Mvc;
using E_Commerce_Application.Data;
using E_Commerce_Application.Models;


namespace E_Commerce_Application.Controllers
{
    [ApiController]
    [Route("Menu")]
    public class CategoryController : Controller
    {

        private readonly CategoryService _categoryService;


        public CategoryController(CategoryService categoryService) =>
            _categoryService = categoryService;

        [HttpGet]
        public async Task<IActionResult> Get(){
            var categoryList = await _categoryService.GetAsync();
            ViewBag.Categories = categoryList;
            return View("Index");
        }
  

        [HttpGet("{id:length(24)}")]
        public async Task<ActionResult<Category>> Get(string id)
        {
            var category = await _categoryService.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }
            ViewBag.Category = category;
            return category;
        }

        [HttpPost]
        public async Task<IActionResult> Post(Category newCategory)
        {
            await _categoryService.CreateAsync(newCategory);

            return CreatedAtAction(nameof(Get), new { id = newCategory.Id }, newCategory);
        }

        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> Update(string id, Category updatedCategory)
        {
            var category = await _categoryService.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            updatedCategory.Id = category.Id;

            await _categoryService.UpdateAsync(id, updatedCategory);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> Delete(string id)
        {
            var category = await _categoryService.GetAsync(id);

            if (category is null)
            {
                return NotFound();
            }

            await _categoryService.RemoveAsync(id);

            return NoContent();
        }
          public IActionResult Index()
            {
                return View();
            }
    }
}
