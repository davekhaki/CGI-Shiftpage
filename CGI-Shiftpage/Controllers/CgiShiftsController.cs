using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CGI_Shiftpage.Models;
using Microsoft.AspNetCore.Cors;

namespace CGI_Shiftpage.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("api/CgiShifts")]
    [ApiController]
    public class CgiShiftsController : ControllerBase
    {
        private readonly CoreDbContext _context;

        public CgiShiftsController(CoreDbContext context)
        {
            _context = context;
        }

        // GET: api/CgiShifts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CgiShift>>> GetCgiShift()
        {
            return await _context.CgiShift.ToListAsync();
        }

        // GET: api/CgiShifts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CgiShift>> GetCgiShift(int id)
        {
            var cgiShift = await _context.CgiShift.FindAsync(id);

            if (cgiShift == null)
            {
                return NotFound();
            }

            return cgiShift;
        }

        // PUT: api/CgiShifts/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCgiShift(int id, CgiShift cgiShift)
        {
            if (id != cgiShift.Id)
            {
                return BadRequest();
            }

            _context.Entry(cgiShift).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CgiShiftExists(id))
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

        // POST: api/CgiShifts
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
        [HttpPost]
        public async Task<ActionResult<CgiShift>> PostCgiShift(CgiShift cgiShift)
        {
            _context.CgiShift.Add(cgiShift);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCgiShift), new { id = cgiShift.Id }, cgiShift);
        }

        // DELETE: api/CgiShifts/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CgiShift>> DeleteCgiShift(int id)
        {
            var cgiShift = await _context.CgiShift.FindAsync(id);
            if (cgiShift == null)
            {
                return NotFound();
            }

            _context.CgiShift.Remove(cgiShift);
            await _context.SaveChangesAsync();

            return cgiShift;
        }

        private bool CgiShiftExists(int id)
        {
            return _context.CgiShift.Any(e => e.Id == id);
        }
    }
}
