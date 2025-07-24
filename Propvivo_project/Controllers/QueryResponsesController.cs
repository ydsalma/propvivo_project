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
    public class QueryResponsesController : ControllerBase
    {
        private readonly EmployeeDbContext _context;

        public QueryResponsesController(EmployeeDbContext context)
        {
            _context = context;
        }

        // GET: api/QueryResponses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<QueryResponse>>> GetQueryResponses()
        {
            return await _context.QueryResponses.ToListAsync();
        }

        // GET: api/QueryResponses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<QueryResponse>> GetQueryResponse(int id)
        {
            var queryResponse = await _context.QueryResponses.FindAsync(id);

            if (queryResponse == null)
            {
                return NotFound();
            }

            return queryResponse;
        }

        // PUT: api/QueryResponses/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutQueryResponse(int id, QueryResponse queryResponse)
        {
            if (id != queryResponse.ResponseId)
            {
                return BadRequest();
            }

            _context.Entry(queryResponse).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QueryResponseExists(id))
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

        // POST: api/QueryResponses
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<QueryResponse>> PostQueryResponse(QueryResponse queryResponse)
        {
            _context.QueryResponses.Add(queryResponse);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetQueryResponse", new { id = queryResponse.ResponseId }, queryResponse);
        }

        // DELETE: api/QueryResponses/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteQueryResponse(int id)
        {
            var queryResponse = await _context.QueryResponses.FindAsync(id);
            if (queryResponse == null)
            {
                return NotFound();
            }

            _context.QueryResponses.Remove(queryResponse);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool QueryResponseExists(int id)
        {
            return _context.QueryResponses.Any(e => e.ResponseId == id);
        }
    }
}
