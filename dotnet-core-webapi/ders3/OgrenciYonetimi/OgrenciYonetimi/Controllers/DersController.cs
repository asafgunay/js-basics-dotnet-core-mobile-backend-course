using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OgrenciYonetimi.Data.DataModels;
using OgrenciYonetimi.Data.EntityFramework;
using OgrenciYonetimi.Data.ViewModels;

namespace OgrenciYonetimi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DersController : ControllerBase
    {
        private readonly OgrenciYonetimDbContext _context;
        public DersController(OgrenciYonetimDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        // Create Ders Method (CreateDersInput diye view model oluşturun)
        public async Task<ActionResult<Ders>> Create(CreateDersInput input)
        {
            Ders newDers = Ders.Create(input.DersAdi, input.SinifId);
            await _context.AddAsync(newDers);
            await _context.SaveChangesAsync();
            return newDers;
        }
        // Get{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Ders>> GetDers(int id)
        {
            return await _context.Dersler
                .Where(x => x.DersId == id)
                .Include(x => x.Sinif)
                .FirstOrDefaultAsync();
        }
        // GetAll
        [HttpGet]
        public async Task<ActionResult<List<Ders>>> GetAllDers()
        {
            return await _context.Dersler
                .Include(x => x.Sinif)
                .ToListAsync();
        }

        // Update HttpPut
        [HttpPut]
        public async Task<ActionResult<Ders>> UpdateDers(UpdateDersInput input)
        {
            Ders eskiHali = await _context.Dersler.FindAsync(input.DersId);
            eskiHali.SinifId = input.SinifId;
            eskiHali.DersAdi = input.DersAdi;
            eskiHali.CreatedDate = eskiHali.CreatedDate;
            //Ders yeniDers = new Ders
            //{
            //    SinifId = input.SinifId,
            //    DersAdi = input.DersAdi,
            //    DersId = input.DersId,         
            //};
            //_context.Entry(yeniDers).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return eskiHali;
        }
        // Delete HttpDelete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDers(int id)
        {
            try
            {
                var ders = await _context.Dersler.FindAsync(id);
                _context.Dersler.Remove(ders);
                await _context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}