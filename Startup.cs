using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication_v._1._1.Models;
using WebApplication_v._1._1.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using WebApplication_v._1._1.Repositories.Abstract;
using WebApplication_v._1._1.Repositories.EntityFramework;
using WebApplication_v._1._1.Domain.Repositories.Abstract;
using WebApplication_v._1._1.Domain.Repositories.EntityFramework;
namespace WebApplication_v._1._1
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        

        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DBContext>(options => options.UseSqlServer(connection));
            services.AddControllersWithViews();
            
            services.AddControllers();

            services.AddScoped<IFilialsRepository, EFFilialsRepository>();
            services.AddScoped<IZayaviteliRepository, EFZayaviteliRepository>();
            services.AddScoped<ISotrudnikiRepository, EFSotrudnikiRepository>();
            services.AddScoped<IPrinZayavRepository, EFPrinZayavRepository>();

            services.AddMvc();

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options => //CookieAuthenticationOptions
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Login/LogIn");
        });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            
            app.UseRouting();

            app.UseAuthentication();    // аутентификация
            app.UseAuthorization();     // авторизация

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
