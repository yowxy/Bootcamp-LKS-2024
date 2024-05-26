using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web_API_LKS.Database;
using Web_API_LKS.DTO;

namespace Web_API_LKS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FightHistoriesController : ControllerBase
    {
        private readonly EsemkaHeroContext _context;

        public FightHistoriesController(EsemkaHeroContext context)
        {
            _context = context;
        }

        // GET: api/FightHistories
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FightHistory>>> GetFightHistories()
        {
            return await _context.FightHistories.ToListAsync();
        }

        // GET: api/FightHistories/5
        [HttpGet("{id}")]
        public async Task<ActionResult<FightHistory>> GetFightHistory(int id)
        {
            var fightHistory = await _context.FightHistories.FindAsync(id);

            if (fightHistory == null)
            {
                return NotFound();
            }

            return fightHistory;
        }

        // PUT: api/FightHistories/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFightHistory(int id, Fheroes fightHistory)
        {
            if (id != fightHistory.Id)
            {
                return BadRequest();
            }

            _context.Entry(fightHistory).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FightHistoryExists(id))
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

        // POST: api/FightHistories
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<FightHistory>> PostFightHistory(Fheroes fightHistory)
        {
            _context.FightHistories.Add(fightHistory);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetFightHistory", new { id = fightHistory.Id }, fightHistory);
        }

        // DELETE: api/FightHistories/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFightHistory(int id)
        {
            var fightHistory = await _context.FightHistories.FindAsync(id);
            if (fightHistory == null)
            {
                return NotFound();
            }

            _context.FightHistories.Remove(fightHistory);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool FightHistoryExists(int id)
        {
            return _context.FightHistories.Any(e => e.Id == id);
        }
    }
}
