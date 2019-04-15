using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.DAL;
using BookStore.WebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        public AuthorController(BookStoreDbContext context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<ActionResult> Create(/*CreateAuthorInput*/)
        {
            return null;
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            return null;
        }
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAll()
        {
            return null;
        }

        [HttpPut]
        public async Task<ActionResult> Update(/*UpdateAuthorInput*/)
        {
            return null;
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            return null;
        }
    }
}