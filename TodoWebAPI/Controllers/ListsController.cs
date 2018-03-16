using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoWebAPI.Data;
using TodoWebAPI.Models;

namespace TodoWebAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/Lists")]
    public class ListsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ListsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/ListModels
        [HttpGet]
        public IEnumerable<ListModel> GetLists()
        {
            return _context.Lists;
        }

        // GET: api/ListModels/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listModel = await _context.Lists.Include(x => x.Elements).SingleOrDefaultAsync(m => m.Id == id);


            if (listModel == null)
            {
                return NotFound();
            }

            return Ok(listModel);
        }

        // PUT: api/ListModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutListModel([FromRoute] int id, [FromBody] ListModel listModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != listModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(listModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ListModelExists(id))
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

        // POST: api/ListModels
        [HttpPost]
        public async Task<IActionResult> PostListModel([FromBody] ListModel listModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Lists.Add(listModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetListModel", new { id = listModel.Id }, listModel);
        }

        // DELETE: api/ListModels/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteListModel([FromRoute] int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var listModel = await _context.Lists.SingleOrDefaultAsync(m => m.Id == id);
            if (listModel == null)
            {
                return NotFound();
            }

            _context.Lists.Remove(listModel);
            await _context.SaveChangesAsync();

            return Ok(listModel);
        }

        private bool ListModelExists(int id)
        {
            return _context.Lists.Any(e => e.Id == id);
        }
    }
}