using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Propvivo_project.Context;
using Propvivo_project.Models;

namespace Propvivo_project.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpTasksController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public EmpTasksController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/EmpTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmpTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/EmpTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EmpTask>> GetEmpTask(int id)
        {
            var empTask = await _context.Tasks.FindAsync(id);

            if (empTask == null)
            {
                return NotFound();
            }

            return empTask;
        }

        // PUT: api/EmpTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpTask(int id, EmpTask empTask)
        {
            if (id != empTask.TaskId)
            {
                return BadRequest();
            }

            _context.Entry(empTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpTaskExists(id))
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

        // POST: api/EmpTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmpTask>> PostEmpTask(EmpTask empTask)
        {
            _context.Tasks.Add(empTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpTask", new { id = empTask.TaskId }, empTask);
        }

        // DELETE: api/EmpTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpTask(int id)
        {
            var empTask = await _context.Tasks.FindAsync(id);
            if (empTask == null)
            {
                return NotFound();
            }

            _context.Tasks.Remove(empTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.TaskId == id);
        }
    }
}
