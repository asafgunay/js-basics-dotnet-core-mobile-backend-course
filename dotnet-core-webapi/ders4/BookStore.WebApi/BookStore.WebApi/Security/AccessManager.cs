using BookStore.WebApi.DAL;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace BookStore.WebApi.Security
{
    public class AccessManager
    {
        private UserManager<ApplicationUser> _userManager;
        private SignInManager<ApplicationUser> _signInManager;
        private SigningConfigurations _signingConfigurations;
        private TokenConfigurations _tokenConfigurations;

        public AccessManager(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
        }

        public bool ValidateCredentials(User user)
        {
            bool credentialValidStatus = false;
            if (user != null && !String.IsNullOrWhiteSpace(user.UserName))
            {
                // kullanıcı sınıfı parametresi doğru ise buraya gelir
                var userIdentity = _userManager.FindByNameAsync(user.UserName).Result;

                if (userIdentity != null)
                {
                    var resultLogin = _signInManager.CheckPasswordSignInAsync
                        (userIdentity,
                        user.Password,
                        false).Result;
                    if (resultLogin.Succeeded)
                    {
                        credentialValidStatus = true;
                    }
                }
            }
            return credentialValidStatus;
        }
        public Token GenerateToken(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                new GenericIdentity(user.UserName, "Login"),
                new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
                });
            DateTime startedDate = DateTime.Now;
            DateTime expiredDate = startedDate + TimeSpan.FromSeconds(3600);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(
                new SecurityTokenDescriptor
                {
                    Issuer = _tokenConfigurations.Issuer,
                    Audience = _tokenConfigurations.Audience,
                    SigningCredentials = _signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = startedDate,
                    Expires = expiredDate
                });
            var token = handler.WriteToken(securityToken);

            return new Token()
            {
                Authenticated = true,
                Created = startedDate.ToString("yyyy-MM-dd HH:mm:ss"),
                Expiration = expiredDate.ToString("yyyy-MM-dd HH:mm:ss"),
                AccessToken = token,
                Message = "OK"
            };

        }
    }
}
