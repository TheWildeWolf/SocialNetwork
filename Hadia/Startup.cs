using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hadia.Concrete;
using Hadia.Core;
using Hadia.Data;
using Hadia.Helper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;

namespace Hadia
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        private static readonly string DEFAULT_CONNECTION_STRING = "Default";
        private static readonly string DEV_CONNECTION_STRING = "Development";
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
                //.AddJsonOptions(opt =>
                //{
                //    opt.SerializerSettings.ReferenceLoopHandling =
                //        Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                //});
            services.AddDbContext<HadiaContext>(op =>
                op.UseSqlServer(Configuration.GetConnectionString(DEV_CONNECTION_STRING)));
            services.AddAutoMapper();
            //AuthCoockie
            services.AddHttpContextAccessor();
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new Info { Title = "Hadia Api", Version = "v1" });
                });
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.AccessDeniedPath = "";
                    options.LoginPath = "/Auth/Login";

                }).AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII
                            .GetBytes(Configuration.GetSection("AppSettings:Token").Value)),
                        ValidateIssuer = false,
                        ValidateAudience = false
                    };
                });
            //Injections
            //services.AddScoped<ActionFilter>();
            services.AddScoped<IAuthService,AuthService>();
            services.AddScoped<IDataFetcher, DataFetcher>();
            services.AddScoped<INotification, Notification>();
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
                app.UseExceptionHandler(builder =>
                {
                    builder.Run(async context =>
                    {
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        var error = context.Features.Get<IExceptionHandlerFeature>();
                        if (error != null)
                        {
                            await context.ShowApplicationError(error.Error.Message, error.Error.InnerException?.Message);
                        }
                    });
                });
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/Hadia/swagger/v1/swagger.json", "Hadia Alumni");

            });
            app.UseRequestLocalization(new RequestLocalizationOptions
            {
                DefaultRequestCulture = new RequestCulture("en-US")
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "Media", "Images")),
                RequestPath = "/Images"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "Media", "Voice")),
                RequestPath = "/voice"
            });
            app.UseStaticFiles(new StaticFileOptions
            {
                FileProvider = new PhysicalFileProvider(
                    Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "Media", "ProfileImage")),
                RequestPath = "/Profile"
            });
            app.UseDirectoryBrowser(new DirectoryBrowserOptions
            {
                FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot", "ChapterImages")),
                RequestPath = new PathString("/ChapterImages")
               
            });

            app.UseMvc(routes =>
            {
                //{ area: exists} {area=member}/{controller=memberlist}/{action=Index}/{id?}
                routes.MapRoute(
                    name: "area",
                    template: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                        name: "default",
                      template: "{area=member}/{controller=memberlist}/{action=Index}/{id?}");
            });
        }
    }
}
