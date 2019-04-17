using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Data.Services;
using DotnetCore.Identity.Data.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;
        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpPost]
        public async Task<ActionResult> Create(CreateBookInput input)
        {
            try
            {
                await _bookService.CreateAsync(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> Get(int id)
        {
            try
            {
                var res = await _bookService.GetAsync(id);
                if (res != null)
                    return Ok(res);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAll()
        {
            try
            {
                var res = await _bookService.GetAllAsync();
                if (res != null)
                    return Ok(res);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Book>> Update(UpdateBookInput input)
        {
            try
            {
                var res = await _bookService.UpdateAsync(input);
                if (res != null)
                    return Ok(res);

                return NoContent();
            }
            catch (Exception ex)
            {
                return NoContent();
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _bookService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound();
            }
        }
    }
}