using ApiProjeKampii.WebApi.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampii.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly Context.ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            var values = _context.Chefs.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult AddChef(Entities.Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Chef added successfully.");
        }

        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var chef = _context.Chefs.Find(id);
            if (chef == null)
            {
                return NotFound("Chef not found.");
            }
            _context.Chefs.Remove(chef);
            _context.SaveChanges();
            return Ok("Chef deleted successfully.");
        }

        [HttpGet("GetChef")]
        public IActionResult GetChef(int id)
        {
            return Ok(_context.Chefs.Find(id));
        }

        [HttpPut]
        public IActionResult UpdateChef(Entities.Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Chef updated successfully.");
        }
    }
}
