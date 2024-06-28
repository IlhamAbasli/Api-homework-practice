using Api_Practice.Data;
using Api_Practice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Practice.Controllers
{
    [Route("api/[controller]/action")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _context;
        public CategoryController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet] 
        public async Task<IActionResult> GetAll()
        {
            var datas = await _context.Categories.ToListAsync();
            return Ok(datas);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Category category)
        {
            if(!ModelState.IsValid) return BadRequest(ModelState);  
            await _context.Categories.AddAsync(category);   
            await _context.SaveChangesAsync();
            return CreatedAtAction("Create", category);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int? id)
        {
            if (id is null) return BadRequest();
            var existCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if(existCategory is null) return NotFound();

            _context.Categories.Remove(existCategory);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Edit([FromQuery] int? id, [FromBody] Category newCategory)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id is null) return BadRequest();
            var existCategory = await _context.Categories.FirstOrDefaultAsync(c => c.Id == id);
            if(existCategory is null) return NotFound();

            existCategory.Name = newCategory.Name;
            await _context.SaveChangesAsync();
            return AcceptedAtAction(nameof(Edit), newCategory);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int? id)
        {
            if(id is null) return BadRequest();
            var existCategory = await _context.Categories.FirstOrDefaultAsync(m => m.Id == id);
            if(existCategory is null) return NotFound();

            return Ok(existCategory);
        }
    }
}
