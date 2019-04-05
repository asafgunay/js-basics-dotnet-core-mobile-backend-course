using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OgrenciYonetimi.Data.DataModels;
using OgrenciYonetimi.Data.EntityFramework;

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
            return await _context.Ogrenciler.FindAsync(id);
        }
    }
}