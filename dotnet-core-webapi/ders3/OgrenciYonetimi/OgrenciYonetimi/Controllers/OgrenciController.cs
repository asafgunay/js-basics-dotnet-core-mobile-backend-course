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
    public class OgrenciController : ControllerBase
    {
        private readonly OgrenciYonetimDbContext _context;

        public OgrenciController(OgrenciYonetimDbContext context)
        {
            _context = context;
        }

        //GET: api/Ogrenci
        [HttpGet("{id}")]
        public async Task<ActionResult<Ogrenci>> GetOgrenci(int id)
        {
            var ogrenci = new Ogrenci();
            ogrenci = await _context.Ogrenciler.FindAsync(id);
            return ogrenci;
        }
        [HttpPost]
        public async Task<Ogrenci> CreateOgrenci([FromBody] CreateOgrenciInput input)
        {
            Ogrenci yeniOgrenci = Ogrenci.Create(input.Adi, input.Soyadi, input.No, input.Cinsiyet, input.SinifId);
            await _context.AddAsync(yeniOgrenci);
            await _context.SaveChangesAsync();
            return yeniOgrenci;
        }
        [HttpGet]
        public async Task<List<Ogrenci>> GetAll()
        {
            List<Ogrenci> ogrenciler =
                await _context.Ogrenciler
                .Include(ogrencilerim => ogrencilerim.Sinif)
                .ToListAsync();
            // bütün sınıfları getir
            //var siniflar = _context.Siniflar.ToList();
            //foreach(var ogrenci in ogrenciler)
            //{
            //    ogrenci.Sinif = siniflar.Where(x => x.SinifId == ogrenci.SinifId).FirstOrDefault();
            //}
            return ogrenciler;
        }
        // Update HttpPut
        [HttpPut]
        public async Task<ActionResult<Ogrenci>> UpdateOgrenci(UpdateOgrenciInput input)
        {
            try
            {
                Ogrenci eskiHali = await _context.Ogrenciler.FindAsync(input.Id);
                eskiHali.Adi = input.Adi;
                eskiHali.Soyadi = input.Soyadi;
                eskiHali.Cinsiyet = input.Cinsiyet;
                eskiHali.No = input.No;
                eskiHali.SinifId = input.SinifId;
                await _context.SaveChangesAsync();
                return Ok(eskiHali);

            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        // Delete HttpDelete
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteOgrenci(int id)
        {
            try
            {
                var ogrenci = await _context.Ogrenciler.FindAsync(id);
                _context.Ogrenciler.Remove(ogrenci);
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