using Microsoft.AspNetCore.Mvc;
using ShoppingApi.Entities;
using ShoppingApi.Services;
using System.Collections.Generic;

namespace ShoppingApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : Controller
    {
        private readonly CategoryServices _CategoryService;

        public CategoriesController(CategoryServices categoryService)
        {
            _CategoryService = categoryService;
        }

        [HttpGet]
        public ActionResult<List<Category>> Get() =>
            _CategoryService.Get();

        [HttpGet("{id)}")]
        public ActionResult<Category> Get(string id)
        {
            var category = _CategoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            return category;
        }

        [HttpPost]
        public ActionResult<Category> Create(Category category)
        {
            _CategoryService.Create(category);

            return CreatedAtRoute("GetCategory", new { id = category.Id.ToString() }, category);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Category categories)
        {
            var category = _CategoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            _CategoryService.Update(id, categories);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var category = _CategoryService.Get(id);

            if (category == null)
            {
                return NotFound();
            }

            _CategoryService.Remove(id);

            return NoContent();
        }
    }
}
