using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DotnetCore.Identity.Data.Entities
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(200)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(250)]
        public string LastName { get; set; }

    }
}
