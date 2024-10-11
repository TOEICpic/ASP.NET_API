using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using APIBackEnd.Data;
using APIBackEnd.Models;

namespace APIBackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class tableMatchesController : ControllerBase
    {
        private readonly ProjectContext _context;

        public tableMatchesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/tableMatches
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tableMatch>>> GettableMatch_1()
        {
            return await _context.tableMatch_1.ToListAsync();
        }

        // GET: api/tableMatches/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tableMatch>> GettableMatch(int id)
        {
            var tableMatch = await _context.tableMatch_1.FindAsync(id);

            if (tableMatch == null)
            {
                return NotFound();
            }

            return tableMatch;
        }

        // PUT: api/tableMatches/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttableMatch(int id, tableMatch tableMatch)
        {
            if (id != tableMatch.id)
            {
                return BadRequest();
            }

            _context.Entry(tableMatch).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tableMatchExists(id))
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

        // POST: api/tableMatches
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tableMatch>> PosttableMatch(tableMatch tableMatch)
        {
            _context.tableMatch_1.Add(tableMatch);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettableMatch", new { id = tableMatch.id }, tableMatch);
        }

        // DELETE: api/tableMatches/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetableMatch(int id)
        {
            var tableMatch = await _context.tableMatch_1.FindAsync(id);
            if (tableMatch == null)
            {
                return NotFound();
            }

            _context.tableMatch_1.Remove(tableMatch);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tableMatchExists(int id)
        {
            return _context.tableMatch_1.Any(e => e.id == id);
        }
    }
}
