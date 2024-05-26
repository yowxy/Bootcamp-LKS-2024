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
    public class ClannnController : ControllerBase
    {
        private readonly EsemkaHeroContext _context;

        public ClannnController(EsemkaHeroContext context)
        {
            _context = context;
        }

        // GET: api/Clannn
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Clan>>> GetClans()
        {
            return await _context.Clans.ToListAsync();
        }

        // GET: api/Clannn/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Clan>> GetClan(int id)
        {
            var clan = await _context.Clans.FindAsync(id);

            if (clan == null)
            {
                return NotFound();
            }

            return clan;
        }

        // PUT: api/Clannn/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClan(int id, Claaan clan)
        {

            clan.Id = id;
            _context.Entry(clan).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return Ok(clan);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClanExists(id))
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

        // POST: api/Clannn
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Clan>> PostClan(Claaan clan)
        {
          //  clan.Id = clan.Id;  
            _context.Clans.Add(clan);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClan", new { id = clan.Id }, clan);
        }

        // DELETE: api/Clannn/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClan(int id)
        {
            var clan = await _context.Clans.FindAsync(id);
            if (clan == null)
            {
                return NotFound();
            }

            _context.Clans.Remove(clan);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClanExists(int id)
        {
            return _context.Clans.Any(e => e.Id == id);
        }
    }
}
