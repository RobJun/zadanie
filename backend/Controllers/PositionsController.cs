using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using backend.models;

namespace backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PositionsController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public PositionsController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Positions
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Position>>> GetPositions()
        {
          if (_context.Positions == null)
          {
              return NotFound();
          }
            return await _context.Positions.ToListAsync();
        }

        // GET: api/Positions/5
       /* [HttpGet("{id}")]
        public async Task<ActionResult<Position>> GetPositions(long id)
        {
          if (_context.Positions == null)
          {
              return NotFound();
          }
            var positions = await _context.Positions.FindAsync(id);

            if (positions == null)
            {
                return NotFound();
            }

            return positions;
        }*/

        // POST: api/Positions
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Position>> PostPositions(Position positions)
        {
          if (_context.Positions == null)
          {
              return Problem("Entity set 'EmployeeContext.Positions'  is null.");
          }
            _context.Positions.Add(positions);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPositions", new { id = positions.id }, positions);
        }

        // DELETE: api/Positions/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePositions(long id)
        {
            if (_context.Positions == null)
            {
                return NotFound();
            }
            var positions = await _context.Positions.FindAsync(id);
            if (positions == null)
            {
                return NotFound();
            }

            var employees = from e in _context.Employees
                            where !_context.PositionsEmployees
                                    .Where(i=> i.PositionId != id)
                                    .Any(i=> i.EmployeeId == e.id)
                            select e;
            _context.Positions.Remove(positions);
            _context.Employees.RemoveRange(employees);
            await _context.SaveChangesAsync();


            return NoContent();
        }

        private bool PositionsExists(long id)
        {
            return (_context.Positions?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
