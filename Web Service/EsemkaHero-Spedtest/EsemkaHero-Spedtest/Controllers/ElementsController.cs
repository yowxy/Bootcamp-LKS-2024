﻿using System;
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
    public class ElementsController : ControllerBase
    {
        private readonly EsemkaHeroContext _context;

        public ElementsController(EsemkaHeroContext context)
        {
            _context = context;
        }

        // GET: api/Elements
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Element>>> GetElements()
        {
            return await _context.Elements.ToListAsync();
        }

        // GET: api/Elements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Element>> GetElement(int id)
        {
            var element = await _context.Elements.FindAsync(id);

            if (element == null)
            {
                return NotFound();
            }

            return element;
        }

        // PUT: api/Elements/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutElement(int id, Elementtttt element)
        {

            element.Id = id;
            _context.Entry(element).State = EntityState.Modified;       

            if (id != element.Id)
            {
                return BadRequest();
            }

            _context.Entry(element).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ElementExists(id))
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

        // POST: api/Elements
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Element>> PostElement(Elementtttt element)
        {
            _context.Elements.Add(element);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetElement", new { id = element.Id }, element);
        }

        // DELETE: api/Elements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteElement(int id)
        {
            var element = await _context.Elements.FindAsync(id);
            if (element == null)
            {
                return NotFound();
            }

            _context.Elements.Remove(element);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ElementExists(int id)
        {
            return _context.Elements.Any(e => e.Id == id);
        }
    }
}
