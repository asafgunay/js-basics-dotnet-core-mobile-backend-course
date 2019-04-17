using DotnetCore.Identity.Data.Entities;
using DotnetCore.Identity.Host.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DotnetCore.Identity.Host.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        readonly UserManager<ApplicationUser> userManager;
        readonly SignInManager<ApplicationUser> signInManager;
        readonly IConfiguration configuration;
        readonly ILogger<AccountController> logger;


        public AccountController(
           UserManager<ApplicationUser> userManager,
           SignInManager<ApplicationUser> signInManager,
           IConfiguration configuration,
           ILogger<AccountController> logger)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
            this.logger = logger;
        }
        [HttpPost]
        [Route("token")]
        public async Task<ActionResult> CreateToken([FromBody] LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                var loginResult = await signInManager.PasswordSignInAsync(loginModel.Username, loginModel.Password, isPersistent: false, lockoutOnFailure: false);

                if (!loginResult.Succeeded)
                {
                    return BadRequest();
                }

                var user = await userManager.FindByNameAsync(loginModel.Username);

                return Ok(GetTokenResponse(user));
            }
            return BadRequest(ModelState);

        }

        [Authorize]
        [HttpPost]
        [Route("refreshtoken")]
        public async Task<ActionResult> RefreshToken()
        {
            var user = await userManager.FindByNameAsync(
                User.Identity.Name ??
                User.Claims.Where(c => c.Properties.ContainsKey("unique_name")).Select(c => c.Value).FirstOrDefault()
                );
            return Ok(GetTokenResponse(user));
        }


        [HttpPost]
        [Route("register")]
        [AllowAnonymous]
        public async Task<ActionResult> Register([FromBody] RegisterModel registerModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser
                {
                    //TODO: Use Automapper instaed of manual binding  

                    UserName = registerModel.Username,
                    FirstName = registerModel.FirstName,
                    LastName = registerModel.LastName,
                    Email = registerModel.Email
                };

                var identityResult = await this.userManager.CreateAsync(user, registerModel.Password);
                if (identityResult.Succeeded)
                {
                    await signInManager.SignInAsync(user, isPersistent: false);
                    return Ok(GetTokenResponse(user));
                }
                else
                {
                    return BadRequest(identityResult.Errors);
                }
            }
            return BadRequest(ModelState);


        }
        private string GetToken(ApplicationUser user)
        {
            var utcNow = DateTime.UtcNow;

            var claims = new Claim[]
            {
                        new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                        new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, utcNow.ToString())
            };

            var signingKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.configuration.GetValue<string>("Tokens:Key")));
            var signingCredentials = new SigningCredentials(signingKey, SecurityAlgorithms.HmacSha256);
            var jwt = new JwtSecurityToken(
                signingCredentials: signingCredentials,
                claims: claims,
                notBefore: utcNow,
                expires: utcNow.AddSeconds(this.configuration.GetValue<int>("Tokens:Lifetime")),
                audience: this.configuration.GetValue<string>("Tokens:Audience"),
                issuer: this.configuration.GetValue<string>("Tokens:Issuer")
                );

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        private JwtTokenResult GetTokenResponse(ApplicationUser user)
        {
            var token = GetToken(user);
            JwtTokenResult result = new JwtTokenResult
            {
                AccessToken = token,
                EncryptedAccessToken = token,
                ExpireInSeconds = this.configuration.GetValue<int>("Tokens:Lifetime"),
                UserId = user.Id
            };
            return result;
        }

    }
}