using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using AspNet.Security.OAuth.Validation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.IO;

namespace ProiectDAW
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)         {             services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)                  .AddJwtBearer(jwtBearerOptions =>                 {                     jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()                     {                         ValidateActor = true,                         ValidateAudience = true,                         ValidateLifetime = true,                         ValidateIssuerSigningKey = true,                         ValidIssuer = "proiect",                         ValidAudience = "proiect",                         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("58df993a-5f13-4d6e-9b8a-b684b86e3367"))                     };                 });              //services.AddCors(options =>             //{             //    options.AddPolicy("CorsPolicy",             //        builder => builder.AllowAnyOrigin()             //        .AllowAnyMethod()             //        .AllowAnyHeader()             //        .AllowCredentials());             //});              services.AddAuthentication();             services.AddMvc();         }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)         {             if (env.IsDevelopment())             {                 app.UseDeveloperExceptionPage();             }              app.Use(async (context, next) => { await next(); if (context.Response.StatusCode == 404 && !Path.HasExtension(context.Request.Path.Value) && !context.Request.Path.Value.StartsWith("/api/")) { context.Request.Path = "index.html"; await next(); } });

            app.UseAuthentication();


            app.UseMvcWithDefaultRoute();
            app.UseDefaultFiles();
            app.UseStaticFiles();

            app.UseMvc();              //app.UseStaticFiles();             //app.UseCors("CorsPolicy");             //app.UseMvcWithDefaultRoute();         }
    }
}
