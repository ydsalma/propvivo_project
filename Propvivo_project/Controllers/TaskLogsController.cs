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
    public class TaskLogsController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public TaskLogsController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/TaskLogs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskLog>>> GetTaskLogs()
        {
            return await _context.TaskLogs.ToListAsync();
        }

        // GET: api/TaskLogs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskLog>> GetTaskLog(int id)
        {
            var taskLog = await _context.TaskLogs.FindAsync(id);

            if (taskLog == null)
            {
                return NotFound();
            }

            return taskLog;
        }

        // PUT: api/TaskLogs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTaskLog(int id, TaskLog taskLog)
        {
            if (id != taskLog.LogId)
            {
                return BadRequest();
            }

            _context.Entry(taskLog).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TaskLogExists(id))
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

        // POST: api/TaskLogs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<TaskLog>> PostTaskLog(TaskLog taskLog)
        {
            _context.TaskLogs.Add(taskLog);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTaskLog", new { id = taskLog.LogId }, taskLog);
        }

        // DELETE: api/TaskLogs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTaskLog(int id)
        {
            var taskLog = await _context.TaskLogs.FindAsync(id);
            if (taskLog == null)
            {
                return NotFound();
            }

            _context.TaskLogs.Remove(taskLog);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TaskLogExists(int id)
        {
            return _context.TaskLogs.Any(e => e.LogId == id);
        }
    }
}
