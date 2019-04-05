using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OgrenciYonetimi.Data.EntityFramework;
using Swashbuckle.AspNetCore.Swagger;

namespace OgrenciYonetimi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // Bu yöntem uygulamanın çalışma zamanı sürecinde çağrılır. Uygulama bütününe kullanacağı hizmetleri eklemek için ConfigureServices metodu kullanılır.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<OgrenciYonetimDbContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("OgrenciYonetimiDatabase")));

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

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger().UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/CoreSwagger/swagger.json",
                    "Swagger Test .NET Core");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
