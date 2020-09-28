using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CarManiac.Server.Data;
using CarManiac.Shared;

namespace CarManiac.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EngineDatasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EngineDatasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/EngineDatas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EngineData>>> GetEnginesData()
        {
            return await _context.EnginesData.ToListAsync();
        }

        // GET: api/EngineDatas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EngineData>> GetEngineData(int id)
        {
            var engineData = await _context.EnginesData.FindAsync(id);

            if (engineData == null)
            {
                return NotFound();
            }

            return engineData;
        }

        // PUT: api/EngineDatas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEngineData(int id, EngineData engineData)
        {
            if (id != engineData.Id)
            {
                return BadRequest();
            }

            _context.Entry(engineData).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EngineDataExists(id))
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

        // POST: api/EngineDatas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EngineData>> PostEngineData(EngineData engineData)
        {
            _context.EnginesData.Add(engineData);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEngineData", new { id = engineData.Id }, engineData);
        }

        // DELETE: api/EngineDatas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEngineData(int id)
        {
            var engineData = await _context.EnginesData.FindAsync(id);
            if (engineData == null)
            {
                return NotFound();
            }

            _context.EnginesData.Remove(engineData);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EngineDataExists(int id)
        {
            return _context.EnginesData.Any(e => e.Id == id);
        }
    }
}
