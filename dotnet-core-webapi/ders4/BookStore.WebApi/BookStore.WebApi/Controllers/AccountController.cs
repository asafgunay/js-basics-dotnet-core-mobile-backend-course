using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.DAL;
using BookStore.WebApi.Security.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(
                    BookStoreDbContext context,
                    UserManager<ApplicationUser> userManager,
                    RoleManager<IdentityRole> roleManager
            )
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody]RegisterInput input)
        {
            if (ModelState.IsValid)
            {
                var userExists = await _userManager.FindByNameAsync(input.Username);
                if (userExists != null)
                {
                    return NotFound();
                }
                ApplicationUser newUser = new ApplicationUser
                {
                    UserName = input.Username,
                    Email = input.Email
                };
                var result = await _userManager.CreateAsync(newUser, input.Password);
                if (!result.Succeeded)
                {
                    return NotFound();
                }
                var newCreatedUserData = await _userManager.FindByNameAsync(input.Username);
                return Ok(newCreatedUserData);
            }
            else
            {
                return NotFound();
            }
        }
    }
}