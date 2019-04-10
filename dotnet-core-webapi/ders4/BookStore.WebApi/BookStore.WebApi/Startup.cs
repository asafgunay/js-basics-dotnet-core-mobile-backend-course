using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStore.WebApi.DAL;
using BookStore.WebApi.Security;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace BookStore.WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookStoreDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookStoreDatabase")));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(
                "CoreSwagger", new Info
                {
                    Title = "ModelVeritabani uygulaması için Swagger",
                    Version = "1.0.0",
                    Description = "API Dokümantasyonu",
                    Contact = new Contact()
                    {
                        Name = "Asaf Günay",
                        Url = "https://butgem.org",
                        Email = "asafgunay@butgem.org"
                    },
                    TermsOfService = "https://butgem.org/Security"
                });
            });

            services.AddIdentityCore<ApplicationUser>()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BookStoreDbContext>()
                .AddSignInManager()
                .AddDefaultTokenProviders();

            services.AddScoped<AccessManager>();

            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();

            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);


            services.AddJwtSecurity(
                signingConfigurations, tokenConfigurations);

            services.AddCors();

            //services.AddAuthentication(auth =>
            //{
            //    auth.DefaultScheme = IdentityConstants.ApplicationScheme;
            //    auth.DefaultSignInScheme = IdentityConstants.ExternalScheme;
            //});

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json",
                    "Swagger Test .NET Core");
            });

            // app.UseAuthorization();
            app.UseMvc();
        }
    }
}
