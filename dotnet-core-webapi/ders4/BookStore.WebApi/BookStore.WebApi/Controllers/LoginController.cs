using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public object Post(
            [FromBody]User userInput,
            [FromServices]AccessManager accessManager)
        {
            if (accessManager.ValidateCredentials(userInput))
            {
                return accessManager.GenerateToken(userInput);
            }
            else
            {
                return new
                {
                    Authenticated = false,
                    Message = "Lütfen kullanıcı adı ve şifrenizi kontrol edin"
                };
            }
        }
    }
}