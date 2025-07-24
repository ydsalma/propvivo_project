﻿using System;
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
    public class QueriesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public QueriesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/Queries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Query>>> GetQueries()
        {
            return await _context.Queries.ToListAsync();
        }

        // GET: api/Queries/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Query>> GetQuery(int id)
        {
            var query = await _context.Queries.FindAsync(id);

            if (query == null)
            {
                return NotFound();
            }

            return query;
        }

        // PUT: api/Queries/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQuery(int id, Query query)
        {
            if (id != query.QueryId)
            {
                return BadRequest();
            }

            _context.Entry(query).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryExists(id))
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

        // POST: api/Queries
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Query>> PostQuery(Query query)
        {
            _context.Queries.Add(query);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQuery", new { id = query.QueryId }, query);
        }

        // DELETE: api/Queries/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQuery(int id)
        {
            var query = await _context.Queries.FindAsync(id);
            if (query == null)
            {
                return NotFound();
            }

            _context.Queries.Remove(query);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QueryExists(int id)
        {
            return _context.Queries.Any(e => e.QueryId == id);
        }
    }
}
