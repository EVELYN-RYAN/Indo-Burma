using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Indo_Burma.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Indo_Burma
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
            services.AddDbContext<BookstoreContext>(options =>
            {
                options.UseSqlite(Configuration["ConnectionStrings:BookDBConnection"]);
            });
            services.AddScoped<IBookRepository, EFBookRepository>();
            services.AddDistributedMemoryCache();
            services.AddRazorPages();
            services.AddSession();

            services.AddScoped<Cart>(x => SessionCart.GetCart(x));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IOrderRepository, EFOrderRepository>();

            services.AddServerSideBlazor().AddCircuitOptions(options => { options.DetailedErrors = true; });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseAuthorization();
            ////Added from 414
            //app.UseHsts();
            ////Added from 414
            //app.Use(async (context, next) =>
            //{
            //    context.Response.Headers.Add("X-Xss-Protection", "1");
            //    await next();
            //});
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catPage", "{bookCat}/{pageNum}", new { Controller = "Home", action = "Index"});
                endpoints.MapControllerRoute("paging", "{pageNum}", new { Controller = "Home", action = "Index", pageNum = "1" });
                endpoints.MapControllerRoute("Category", "{bookCat}", new { Controller = "Home", action = "Index", pageNum = "1" });
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/admin/{*catchall}", "/Admin/Index");
            });
        }
    }
}
