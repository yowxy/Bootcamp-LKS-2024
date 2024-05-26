using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Web_API_LKS.Database;
using Web_API_LKS.DTO;

namespace Web_API_LKS.Controllers
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
            var skil = await _context.HeroSkills.Include(f => f.Hero).ToListAsync();
            return Ok(skil.Select(e =>
            {
                return JsonConvert.DeserializeObject<HeroSKILL>(JsonConvert.SerializeObject(e));
            }).ToList());
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

            return Ok(JsonConvert.DeserializeObject<HeroSKILL>(JsonConvert.SerializeObject(heroSkill))); 
        }

        // PUT: api/HeroSkills/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHeroSkill(int id, HeroSkill heroSkill)
        {

            heroSkill.Id = id;
            _context.Entry(heroSkill).State = EntityState.Modified;     

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
        public async Task<ActionResult<HeroSkill>> PostHeroSkill(HeroSKILL heroSkil)
        {
           
          

            _context.HeroSkills.Add(heroSkil);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHeroSkill", new { id = heroSkil.Id }, heroSkil);

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
