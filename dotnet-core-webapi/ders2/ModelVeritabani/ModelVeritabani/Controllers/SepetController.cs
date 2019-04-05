using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelVeritabani.Data;
using ModelVeritabani.Models;
using ModelVeritabani.ViewModels;

namespace ModelVeritabani.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SepetController : ControllerBase
    {
        private ModelVeritabaniContext _context;
        public SepetController(ModelVeritabaniContext context)
        {
            _context = context;
        }

        [HttpGet]
        public ActionResult<List<Sepet>> GetAll()
        {
            List<Sepet> sepettekiler = _context.Sepets.ToList();
            return sepettekiler;
        }
        [HttpGet]
        public ActionResult<Sepet> Get(int id)
        {
            Sepet sepettekiler = _context.Sepets.Find(id);
            return sepettekiler;
        }
        [HttpPost]
        public void Post([FromBody] CreateSepetInput input)
        {
            // AutoMapper'sız
            Sepet item = new Sepet
            {
                CategoryName = input.CategoryName,
                Price = input.Price,
                ProductName = input.ProductName,
                Quantity = input.Quantity
            };
            _context.Add(item);
            _context.SaveChanges();
        }
        
        [HttpPut]
        public ActionResult<Sepet> Update([FromBody] UpdateModel yeniHali)
        {
            // var olan sepeti getirelim
            Sepet mevcutHali = _context.Sepets.Find(yeniHali.Id);
            mevcutHali.CategoryName = yeniHali.CategoryName;
            mevcutHali.ProductName = yeniHali.ProductName;
            _context.SaveChanges();
            return _context.Sepets.Find(yeniHali.Id);

        }
    }
}