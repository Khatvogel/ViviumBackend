using System.IO;
using Backend.Data;
using Backend.Interfaces.Firebase;
using Backend.Interfaces.Repositories;
using Backend.Repository;
using Backend.Repository.Firebase;
using Frontend.Services.SignalR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using JavaScriptEngineSwitcher.ChakraCore;
using JavaScriptEngineSwitcher.Extensions.MsDependencyInjection;
using Microsoft.AspNetCore.Http;
using React.AspNet;

namespace Frontend
{
    public class Startup
    {
        public Startup(IWebHostEnvironment environment)
        {
            Environment = environment;
        }

        private IWebHostEnvironment Environment { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite($"DataSource={Path.Combine(Environment.ContentRootPath, "app.db")}"));

            services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.AddCors(options => options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.WithOrigins("http://localhost:5001")
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials();
                }));
            
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddReact();
            services.AddJsEngineSwitcher(options => options.DefaultEngineName = ChakraCoreJsEngine.EngineName)
                .AddChakraCore();
            
            services.AddRazorPages();
            services.AddControllers();
            services.AddSignalR().AddNewtonsoftJsonProtocol(p =>
            {
                p.PayloadSerializerSettings.ReferenceLoopHandling =
                    ReferenceLoopHandling.Ignore;
            });
            

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo {Title = "Vivium API", Version = "v1"});
            });

            services.AddScoped<IHintRepository, HintRepository>();
            services.AddScoped<IDeviceRepository, DeviceRepository>();
            services.AddScoped<IAttemptRepository, AttemptRepository>();
            services.AddScoped<IGameSequenceRepository, GameSequenceRepository>();
            services.AddScoped<IAttemptDeviceRepository, AttemptDeviceRepository>();
            services.AddScoped<IFireBaseDeviceRepository, FireBaseDeviceRepository>();
            services.AddHttpClient<IFireBaseDeviceRepository, FireBaseDeviceRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment() || env.IsProduction())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }


            // Initialise ReactJS.NET. Must be before static files.
            app.UseReact(config =>
            {
                config.AddScript("~/material-dashboard/assets/js/dashboard-devices/devices.js");
                
                // If you use an external build too (for example, Babel, Webpack,
                // Browserify or Gulp), you can improve performance by disabling
                // ReactJS.NET's version of Babel and loading the pre-transpiled
                // scripts. Example:
                //config
                //  .SetLoadBabel(false)
                //  .AddScriptWithoutTransform("~/js/bundle.server.js");
            });
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(c => { c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1"); });
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
                endpoints.MapHub<HintsHub>("/hintsHub");
            });
        }
    }
}