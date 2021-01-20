using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactTube.Data;
using ReactTube.Models;
using Newtonsoft.Json.Serialization;

namespace ReactTube
{
    public class Startup
    {
        public Startup(IConfiguration configuration, IHostEnvironment env)
        {
            Configuration = configuration;
            _env = env;
        }
        public IHostEnvironment _env { get; }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseSqlServer
                (Configuration.GetConnectionString("ReactTubeConnection")));

            //services.AddControllers();
            services.AddControllers()
                .AddNewtonsoftJson(options =>
                options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
            );
            //services.AddScoped<IVideoRepo, MockVideosRepo>();
            //services.AddScoped<IUserRepo, MockUsersRepo>();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //services.AddScoped<IUserRepo, SqlUsersRepo>();
            services.AddScoped<IVideoRepo, SqlVideosRepo>();
            services.AddScoped<IApplicationUserRepo, SqlApplicationUserRepo>();

            //Users identities
            services.AddIdentity<ApplicationUser, IdentityRole>()
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();


            // ********************
            // Setup CORS
            // ********************
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            //corsBuilder.AllowAnyOrigin(); // For anyone access.
            corsBuilder.WithOrigins("http://localhost:3000"); // for a specific url. Don't add a forward slash on the end!
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("SiteCorsPolicy", corsBuilder.Build());
            });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseAuthentication();
            app.UseAuthorization();
            app.UseRouting();
            app.UseCors();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
