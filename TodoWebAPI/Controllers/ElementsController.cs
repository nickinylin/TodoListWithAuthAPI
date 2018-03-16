using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;
using TodoWebAPI.Models;

namespace TodoWebAPI.Controllers
{
    [Authorize(Policy = "ApiUser")]
    //[Authorize]
    [Produces("application/json")]
    [Route("api/Elements")]
    public class ElementsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ElementsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Elements
        [HttpGet]
        public IEnumerable<ElementModel> GetElements()
        {
            return _context.Elements;
        }

        //[HttpGet]
        //public IEnumerable<ElementModel> GetElementsFromList()
        //{
        //    return _context.Elements;
        //}

        // GET: api/ElementModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetElementModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementModel = await _context.Elements.SingleOrDefaultAsync(m => m.Id == id);

            if (elementModel == null)
            {
                return NotFound();
            }

            return Ok(elementModel);
        }

        // PUT: api/ElementModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElementModel([FromRoute] int id, [FromBody] ElementModel elementModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != elementModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(elementModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ElementModels
        [HttpPost]
        public async Task<IActionResult> PostElementModel([FromBody] ElementModel elementModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Elements.Add(elementModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElementModel", new { id = elementModel.Id }, elementModel);
        }

        // DELETE: api/ElementModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElementModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var elementModel = await _context.Elements.SingleOrDefaultAsync(m => m.Id == id);
            if (elementModel == null)
            {
                return NotFound();
            }

            _context.Elements.Remove(elementModel);
            await _context.SaveChangesAsync();

            return Ok(elementModel);
        }

        private bool ElementModelExists(int id)
        {
            return _context.Elements.Any(e => e.Id == id);
        }
    }
}