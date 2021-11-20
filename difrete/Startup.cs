using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Template.Data.Context;
using Microsoft.EntityFrameworkCore;
using Template.Ioc;
using Template.Application.AutoMapper;
using AutoMapper;
using Template.Swagger;
using System.Text;
using Template.Auth.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;

namespace difrete
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
            services.AddControllersWithViews();

            services.AddDbContext<TemplateContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("TemplateDB")).EnableSensitiveDataLogging());
            NativeInjector.RegisterServices(services);

            services.AddAutoMapper(typeof(AutoMapperSetup));
            services.AddSwaggerConfiguration();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseExceptionHandler(errorApp =>
            {
                errorApp.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    context.Response.ContentType = "application/json";

                    var exceptionHandlerPathFeature =
                        context.Features.Get<IExceptionHandlerPathFeature>();


                    var bytes = Encoding.UTF8.GetBytes("{ \"message\": \"" + exceptionHandlerPathFeature.Error.Message + "\" }");

                    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);

                });
            });

            //app.UseExceptionHandler("/Home/Error");
            //app.UseExceptionHandler("/MainFretista/Error");
            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

            app.UseSwaggerConfiguration();

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MainFretista}/{action=MainFretista}/{id?}"); //aqui que a gente faz a rota das paradas
                //Link referente a route: https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-6.0
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=MainContratante}/{action=MainContratante}/{id?}"); //aqui que a gente faz a rota das paradas
                //Link referente a route: https://docs.microsoft.com/pt-br/aspnet/core/fundamentals/routing?view=aspnetcore-6.0
            });

        }
    }
}
