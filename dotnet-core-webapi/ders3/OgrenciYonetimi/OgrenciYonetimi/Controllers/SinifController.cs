using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciYonetimi.Data.DataModels;
using OgrenciYonetimi.Data.EntityFramework;

namespace OgrenciYonetimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SinifController : ControllerBase
    {
        private readonly OgrenciYonetimDbContext _context;

        public SinifController(OgrenciYonetimDbContext context)
        {
            _context = context;
        }

        // GET: api/Sinif
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Sinif>>> GetSiniflar()
        {
            return await _context.Siniflar.ToListAsync();
        }

        // GET: api/Sinif/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Sinif>> GetSinif(int id)
        {
            var sinif = await _context.Siniflar.FindAsync(id);

            if (sinif == null)
            {
                return NotFound();
            }

            return sinif;
        }

        // PUT: api/Sinif/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSinif(int id, Sinif sinif)
        {
            if (id != sinif.SinifId)
            {
                return BadRequest();
            }

            _context.Entry(sinif).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SinifExists(id))
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

        // POST: api/Sinif
        [HttpPost]
        public async Task<ActionResult<Sinif>> PostSinif(Sinif sinif)
        {
            _context.Siniflar.Add(sinif);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSinif", new { id = sinif.SinifId }, sinif);
        }

        // DELETE: api/Sinif/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Sinif>> DeleteSinif(int id)
        {
            var sinif = await _context.Siniflar.FindAsync(id);
            if (sinif == null)
            {
                return NotFound();
            }

            _context.Siniflar.Remove(sinif);
            await _context.SaveChangesAsync();

            return sinif;
        }

        private bool SinifExists(int id)
        {
            return _context.Siniflar.Any(e => e.SinifId == id);
        }
    }
}
