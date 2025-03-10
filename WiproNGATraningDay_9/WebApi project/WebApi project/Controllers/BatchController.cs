using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi_project.Data;
using WebApi_project.Models;

namespace WebApi_project.Controllers
{
  

        [Route("api/[controller]")]
        [ApiController]
        public class BatchController : ControllerBase
        {
            private readonly AppDbContext _context;

            public BatchController(AppDbContext context)
            {
                _context = context;
            }

            // Get All Batches
            [HttpGet]
            public async Task<ActionResult<IEnumerable<Batch>>> GetBatches()
            {
                return await _context.Batches.ToListAsync();
            }

            // Get Batch by Id
            [HttpGet("{id}")]
            public async Task<ActionResult<Batch>> GetBatch(int id)
            {
                var batch = await _context.Batches.FindAsync(id);
                if (batch == null) return NotFound();
                return batch;
            }

            // Create a New Batch
            [HttpPost]
            public async Task<ActionResult<Batch>> PostBatch(Batch batch)
            {
                _context.Batches.Add(batch);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetBatch), new { id = batch.BatchId }, batch);
            }

            // Update a Batch
            [HttpPut("{id}")]
            public async Task<IActionResult> PutBatch(int id, Batch batch)
            {
                if (id != batch.BatchId) return BadRequest();

                _context.Entry(batch).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return NoContent();
            }

            // Delete a Batch
            [HttpDelete("{id}")]
            public async Task<IActionResult> DeleteBatch(int id)
            {
                var batch = await _context.Batches.FindAsync(id);
                if (batch == null) return NotFound();

                _context.Batches.Remove(batch);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

    }
