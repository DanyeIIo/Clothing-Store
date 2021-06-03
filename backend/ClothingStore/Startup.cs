using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClothingStore.Models;
using NuxtIntegration.Helpers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.Certificate;

namespace ClothingStore
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
            //        services.AddAuthentication(
            //            CertificateAuthenticationDefaults.AuthenticationScheme)
            //            .AddCertificate()
            //// Adding an ICertificateValidationCache results in certificate auth caching the results.
            //// The default implementation uses a memory cache.
            //            .AddCertificateCache();

            services.AddHttpsRedirection(options =>
            {
                options.RedirectStatusCode = StatusCodes.Status307TemporaryRedirect;
                options.HttpsPort = 44344;
            });
            services.AddHsts(options =>
            {
                options.Preload = true;
                options.IncludeSubDomains = true;
                options.MaxAge = TimeSpan.FromDays(60);
                options.ExcludedHosts.Add("us.example.com");
                options.ExcludedHosts.Add("www.example.com");
            });
            services.AddControllers();
            services.AddSpaStaticFiles(options => options.RootPath = "client-app/dist");
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ClothingStore", Version = "v1" });
            });
            //var connection = @"Server = MSI; Database = ClothingStore; Trusted_Connection = True;";

            services.AddDbContext<ClothingStoreContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("ClothingStoreContext")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //app.UseAuthentication();
            //app.UseSpa(spa =>
            //{
            //    spa.Options.SourcePath = "client-app";
            if (env.IsDevelopment())
            {
                //spa.UseNuxtDevelopmentServer();
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "ClothingStore v1"));
            }
            else
            {
                app.UseHsts();
            }
            //});

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            //app.UseSpaStaticFiles();

        }
    }
}
