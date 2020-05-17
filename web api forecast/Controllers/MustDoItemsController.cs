using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_api_forecast.Models;

namespace web_api_forecast.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MustDoItemsController : ControllerBase
    {
        private readonly MustDoContext _context;

        public MustDoItemsController(MustDoContext context)
        {
            _context = context;
        }

        // GET: api/MustDoItems
        [HttpGet]
        public async Task<ActionResult<IEnumerable<MustDoItem>>> GetMustDoItems()
        {
            return await _context.MustDoItems.ToListAsync();
        }

        // GET: api/MustDoItems/5
        [HttpGet("{id}")]
        public async Task<ActionResult<MustDoItem>> GetMustDoItem(long id)
        {
            var mustDoItem = await _context.MustDoItems.FindAsync(id);

            if (mustDoItem == null)
            {
                return NotFound();
            }

            return mustDoItem;
        }

        // PUT: api/MustDoItems/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutMustDoItem(long id, MustDoItem mustDoItem)
        {
            if (id != mustDoItem.Id)
            {
                return BadRequest();
            }

            _context.Entry(mustDoItem).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MustDoItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return Ok(mustDoItem);
        }

        // POST: api/MustDoItems
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<MustDoItem>> PostMustDoItem(MustDoItem mustDoItem)
        {
            _context.MustDoItems.Add(mustDoItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetMustDoItem", new { id = mustDoItem.Id }, mustDoItem);
        }

        // DELETE: api/MustDoItems/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<MustDoItem>> DeleteMustDoItem(long id)
        {
            var mustDoItem = await _context.MustDoItems.FindAsync(id);
            if (mustDoItem == null)
            {
                return NotFound();
            }

            _context.MustDoItems.Remove(mustDoItem);
            await _context.SaveChangesAsync();

            return mustDoItem;
        }

        private bool MustDoItemExists(long id)
        {
            return _context.MustDoItems.Any(e => e.Id == id);
        }
    }
}
