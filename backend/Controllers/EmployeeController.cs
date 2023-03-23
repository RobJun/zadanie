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
    public class EmployeeController : ControllerBase
    {
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }

        // GET: api/Employee
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {

          if (_context.Employees == null)
          {
              return NotFound();
          }
            return await _context.Employees.ToListAsync();
        }

        [HttpGet("actual/")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployed()
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }

          var employees = from e in _context.Employees
                            join ps in _context.PositionsEmployees
                                on e.id equals ps.EmployeeId into empPos
                            from pe in empPos.DefaultIfEmpty()
                            where pe.End == null 
                            select e;
        return await employees.ToListAsync();
        }

        [HttpGet("archived/")]
        public async Task<ActionResult<IEnumerable<Employee>>> GetArchivedEmployees()
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }

          var employees = _context.Employees.Except(from e in _context.Employees
                            join ps in _context.PositionsEmployees
                                on e.id equals ps.EmployeeId into empPos
                            from pe in empPos.DefaultIfEmpty()
                            where pe.End == null 
                            select e);
        return await employees.ToListAsync();
        }

        // GET: api/Employee/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployees(long id)
        {
          if (_context.Employees == null)
          {
              return NotFound();
          }
            var employees = await _context.Employees.FindAsync(id);

            if (employees == null)
            {
                return NotFound();
            }

            return employees;
        }

        // PUT: api/Employee/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployees(long id, EmployeeCreation e)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null){
                return NotFound();
            }
            List<PositionsEmployee> p = employee.Positions.ToList();
            var index = p.FindIndex(i=> i.End == null);

            if(DateOnly.FromDateTime(DateTime.Now) <= e.DateOfBirth){
                return BadRequest($"Date of birth should be smaller than {DateOnly.FromDateTime(DateTime.Now)}");
            }
            if(e.StartingDate != employee.StartingDate && e.PositionId != p[index].PositionId && DateOnly.FromDateTime(DateTime.Now) > e.StartingDate){
                return BadRequest($"Starting date should be greater or equal to {DateOnly.FromDateTime(DateTime.Now)}");
            }
                
            employee.Name = e.Name;
            employee.LastName = e.LastName;
            employee.Address = e.Address;
            employee.DateOfBirth = e.DateOfBirth;
            employee.StartingDate = e.StartingDate;
            employee.Salary = e.Salary;


            p[index].End = e.StartingDate;
            p.Add(new PositionsEmployee(){
                Employee = employee,
                PositionId = e.PositionId,
                Position = await _context.Positions.FindAsync(e.PositionId),
                Start = e.StartingDate
            });
            employee.Positions = p;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
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

        [HttpPut("{id}/archive")]
        public async Task<IActionResult> archiveEmployees(long id)
        {
            var employee = await _context.Employees.FindAsync(id);
            if(employee == null){
                return NotFound();
            }
            List<PositionsEmployee> p = employee.Positions.ToList();
            var index = p.FindIndex(i=> i.End == null);
            if(index == -1){
                return NotFound();
            }

            p[index].End = DateOnly.FromDateTime(DateTime.Now);
            employee.Positions = p;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeesExists(id))
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

        // POST: api/Employee
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Employee>> PostEmployees(EmployeeCreation e)
        {
          if (_context.Employees == null)
          {
            return Problem("Entity set 'EmployeeContext.Employees'  is null.");
          }
          if(DateOnly.FromDateTime(DateTime.Now) <= e.DateOfBirth){
            return BadRequest($"Date of birth should be smaller than {DateOnly.FromDateTime(DateTime.Now)}");
          }
          if(DateOnly.FromDateTime(DateTime.Now) > e.StartingDate){
            return BadRequest($"Starting date should be greater or equal to {DateOnly.FromDateTime(DateTime.Now)}");
          }

            var employee = new Employee(){
                Name = e.Name,
                LastName = e.LastName,
                Address = e.Address,
                DateOfBirth = e.DateOfBirth,
                StartingDate = e.StartingDate,
                Salary = e.Salary

            };
            
            var position = new PositionsEmployee() {
                Employee = employee,
                PositionId = e.PositionId,
                Position = await _context.Positions.FindAsync(e.PositionId),
                Start = e.StartingDate
            };

            //employee.Positions.Add(position);


           //_context.Employees.Add(employee);
            _context.PositionsEmployees.Add(position);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmployees", new { id = employee.id }, employee);
        }

        // DELETE: api/Employee/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployees(long id)
        {
            if (_context.Employees == null)
            {
                return NotFound();
            }
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeesExists(long id)
        {
            return (_context.Employees?.Any(e => e.id == id)).GetValueOrDefault();
        }
    }
}
