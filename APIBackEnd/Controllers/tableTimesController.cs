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
    public class tableTimesController : ControllerBase
    {
        private readonly ProjectContext _context;

        public tableTimesController(ProjectContext context)
        {
            _context = context;
        }

        // GET: api/tableTimes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<tableTime>>> GettableTime_1()
        {
            return await _context.tableTime_1.ToListAsync();
        }

        // GET: api/tableTimes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<tableTime>> GettableTime(int id)
        {
            var tableTime = await _context.tableTime_1.FindAsync(id);

            if (tableTime == null)
            {
                return NotFound();
            }

            return tableTime;
        }

        // PUT: api/tableTimes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PuttableTime(int id, tableTime tableTime)
        {
            if (id != tableTime.id)
            {
                return BadRequest();
            }

            _context.Entry(tableTime).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!tableTimeExists(id))
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

        // POST: api/tableTimes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<tableTime>> PosttableTime(tableTime tableTime)
        {
            _context.tableTime_1.Add(tableTime);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GettableTime", new { id = tableTime.id }, tableTime);
        }

        // DELETE: api/tableTimes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletetableTime(int id)
        {
            var tableTime = await _context.tableTime_1.FindAsync(id);
            if (tableTime == null)
            {
                return NotFound();
            }

            _context.tableTime_1.Remove(tableTime);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool tableTimeExists(int id)
        {
            return _context.tableTime_1.Any(e => e.id == id);
        }
    }
}
