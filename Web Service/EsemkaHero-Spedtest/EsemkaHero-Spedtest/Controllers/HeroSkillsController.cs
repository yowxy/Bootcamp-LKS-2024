using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EsemkaHero_Spedtest.Database;
using EsemkaHero_Spedtest.DTO;

namespace EsemkaHero_Spedtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroSkillsController : ControllerBase
    {
        private readonly EsemkaHeroContext _context;

        public HeroSkillsController(EsemkaHeroContext context)
        {
            _context = context;
        }

        // GET: api/HeroSkills
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HeroSkill>>> GetHeroSkills()
        {
            return await _context.HeroSkills.ToListAsync();
        }

        // GET: api/HeroSkills/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HeroSkill>> GetHeroSkill(int id)
        {
            var heroSkill = await _context.HeroSkills.FindAsync(id);

            if (heroSkill == null)
            {
                return NotFound();
            }

            return heroSkill;
        }

        // PUT: api/HeroSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroSkill(int id, HeroSKILLL heroSkill)
        {
            if (id != heroSkill.Id)
            {
                return BadRequest();
            }

            _context.Entry(heroSkill).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HeroSkillExists(id))
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

        // POST: api/HeroSkills
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HeroSkill>> PostHeroSkill(HeroSKILLL heroSkill)
        {
            _context.HeroSkills.Add(heroSkill);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroSkill", new { id = heroSkill.Id }, heroSkill);
        }

        // DELETE: api/HeroSkills/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHeroSkill(int id)
        {
            var heroSkill = await _context.HeroSkills.FindAsync(id);
            if (heroSkill == null)
            {
                return NotFound();
            }

            _context.HeroSkills.Remove(heroSkill);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool HeroSkillExists(int id)
        {
            return _context.HeroSkills.Any(e => e.Id == id);
        }
    }
}
