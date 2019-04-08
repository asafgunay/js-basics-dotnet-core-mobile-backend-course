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
    public class OgrenciDersController : ControllerBase
    {
        private readonly OgrenciYonetimDbContext _context;
        public OgrenciDersController(OgrenciYonetimDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<OgrenciDers>> CreateOgrenciDers(CreateOgrenciDersInput input)
        {
            try
            {
                OgrenciDers ogrenciDers = OgrenciDers.Create(input.DersId, input.OgrenciId);
                await _context.AddAsync(ogrenciDers);
                await _context.SaveChangesAsync();
                return Ok(ogrenciDers);
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<OgrenciDersleri>>> GetAll()
        {
            try
            {
                var list = await _context.OgrenciDersler.ToListAsync();
                List<int?> listOgrenciIdler = list.Select(x => x.OgrenciId).ToList();
                HashSet<int?> ogrenciIdler = new HashSet<int?>(listOgrenciIdler);
                var ogrenciler = await _context.Ogrenciler
                    .Where(x => ogrenciIdler.Contains(x.OgrenciId))
                    .ToListAsync();
                List<OgrenciDersleri> ogrencilerinDersleri = new List<OgrenciDersleri>();
                foreach(var ogrenci in ogrenciler)
                {
                    OgrenciDersleri ogr = new OgrenciDersleri();
                    ogr.Ogrenci = ogrenci;
                    List<int?> listDersIdler = list.Where(x => x.OgrenciId == ogrenci.OgrenciId).Select(x => x.DersId).ToList();

                    HashSet<int?> listDerslerId =new HashSet<int?>(
                        listDersIdler
                        );
                    ogr.OgrencininDersleri = await _context.Dersler.Where(x => listDerslerId.Contains(x.DersId)).ToListAsync();
                    ogrencilerinDersleri.Add(ogr);
                }
                return Ok(ogrencilerinDersleri);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }
    }
}