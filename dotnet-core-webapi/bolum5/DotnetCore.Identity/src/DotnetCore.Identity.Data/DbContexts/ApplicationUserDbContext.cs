using System;
using System.Collections.Generic;
using System.Text;
using DotnetCore.Identity.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DotnetCore.Identity.Data.DbContexts {
    public class ApplicationUserDbContext : IdentityDbContext<ApplicationUser> {
        public ApplicationUserDbContext (DbContextOptions<ApplicationUserDbContext> options) : base (options) {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<Author> Authors { get; set; }

    }
}