using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Data.Services;
using DotnetCore.Identity.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DotnetCore.Identity.Host.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorSevice _AuthorService;
        public AuthorController(IAuthorSevice AuthorService)
        {
            _AuthorService = AuthorService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreateAuthorInput input)
        {
            try
            {
                await _AuthorService.CreateAsync(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Author>> Get(int id)
        {
            try
            {
                var result = await _AuthorService.GetAsync(id);
                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpGet]
        public async Task<ActionResult<List<Author>>> GetAll()
        {
            try
            {
                var result = await _AuthorService.GetAllAsync();
                if (result != null)
                {
                    return Ok(result);
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }

        [HttpPut]
        public async Task<ActionResult<Author>> Update(UpdateAuthorInput input)
        {
            try
            {
                return await _AuthorService.UpdateAsync(input);
            }
            catch (Exception ex)
            {

                return NotFound(ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                await _AuthorService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}