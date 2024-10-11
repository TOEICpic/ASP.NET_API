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
    public class tableLeaguesController : ControllerBase
    {
        private readonly ProjectContext _context;

        public tableLeaguesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/tableLeagues
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tableLeagues>>> GettableLeagues()
        {
            return await _context.tableLeagues.ToListAsync();
        }

        // GET: api/tableLeagues/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tableLeagues>> GettableLeagues(int id)
        {
            var tableLeagues = await _context.tableLeagues.FindAsync(id);

            if (tableLeagues == null)
            {
                return NotFound();
            }

            return tableLeagues;
        }

        // PUT: api/tableLeagues/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttableLeagues(int id, tableLeagues tableLeagues)
        {
            if (id != tableLeagues.id)
            {
                return BadRequest();
            }

            _context.Entry(tableLeagues).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tableLeaguesExists(id))
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

        // POST: api/tableLeagues
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tableLeagues>> PosttableLeagues(tableLeagues tableLeagues)
        {
            _context.tableLeagues.Add(tableLeagues);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (tableLeaguesExists(tableLeagues.id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GettableLeagues", new { id = tableLeagues.id }, tableLeagues);
        }

        // DELETE: api/tableLeagues/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetableLeagues(int id)
        {
            var tableLeagues = await _context.tableLeagues.FindAsync(id);
            if (tableLeagues == null)
            {
                return NotFound();
            }

            _context.tableLeagues.Remove(tableLeagues);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tableLeaguesExists(int id)
        {
            return _context.tableLeagues.Any(e => e.id == id);
        }
    }
}
