using ApiProjeKampii.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampii.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly Context.ApiContext _context;

        public CategoriesController(Context.ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetCategories()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(Entities.Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Category created successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Category deleted successfully.");
        }

        [HttpGet("GetCategory")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found.");
            }
            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Category updated successfully.");
        }
    }
}
