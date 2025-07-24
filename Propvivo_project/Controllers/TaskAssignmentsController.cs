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
    public class TaskAssignmentsController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public TaskAssignmentsController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskAssignments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskAssignment>>> GetTaskAssignments()
        {
            return await _context.TaskAssignments.ToListAsync();
        }

        // GET: api/TaskAssignments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskAssignment>> GetTaskAssignment(int id)
        {
            var taskAssignment = await _context.TaskAssignments.FindAsync(id);

            if (taskAssignment == null)
            {
                return NotFound();
            }

            return taskAssignment;
        }

        // PUT: api/TaskAssignments/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskAssignment(int id, TaskAssignment taskAssignment)
        {
            if (id != taskAssignment.AssignmentId)
            {
                return BadRequest();
            }

            _context.Entry(taskAssignment).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskAssignmentExists(id))
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

        // POST: api/TaskAssignments
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskAssignment>> PostTaskAssignment(TaskAssignment taskAssignment)
        {
            _context.TaskAssignments.Add(taskAssignment);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskAssignment", new { id = taskAssignment.AssignmentId }, taskAssignment);
        }

        // DELETE: api/TaskAssignments/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskAssignment(int id)
        {
            var taskAssignment = await _context.TaskAssignments.FindAsync(id);
            if (taskAssignment == null)
            {
                return NotFound();
            }

            _context.TaskAssignments.Remove(taskAssignment);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskAssignmentExists(int id)
        {
            return _context.TaskAssignments.Any(e => e.AssignmentId == id);
        }
    }
}
