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
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        public PublisherController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpPost]
        public async Task<ActionResult> Create(CreatePublisherInput input)
        {
            try
            {
                await _publisherService.CreateAsync(input);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Publisher>> Get(int id)
        {
            try
            {
                var result = await _publisherService.GetAsync(id);
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
        public async Task<ActionResult<List<Publisher>>> GetAll()
        {
            try
            {
                var result = await _publisherService.GetAllAsync();
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
        public async Task<ActionResult<Publisher>> Update(UpdatePublisherInput input)
        {
            try
            {
                return await _publisherService.UpdateAsync(input);
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
                await _publisherService.DeleteAsync(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex);
            }
        }
    }
}