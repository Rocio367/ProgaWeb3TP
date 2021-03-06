using GestorDePedidos.Entidades;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Repositorios;
using Servicios;
using System;
using System.Security.Claims;

namespace SitioWeb
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
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                // options.IdleTimeout = TimeSpan.FromMinutes(30); // ponemos esto?
                options.Cookie.Name = ".MiAPP.Session";

            });

            services.AddControllersWithViews();
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options => {
                    options.LoginPath = "/Ingreso/login";
                    options.AccessDeniedPath = "/Ingreso/Denegado";
                });
            services.AddDbContext<_20211CTPContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("_20211CTPContext")));

            services.AddScoped<IServicioArticulo, ServicioArticulo>();
            services.AddScoped<IRepositorioArticulo, RepositorioArticulo>();
            services.AddScoped<IServicioCliente, ServicioCliente>();
            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddScoped<IServicioPedido, ServicioPedido>();
            services.AddScoped<IRepositorioPedido, RepositorioPedido>();
        }



        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                 app.UseDeveloperExceptionPage();
                //app.UseExceptionHandler("/Home/Error");

            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Ingreso}/{action=Login}/{id?}");
            });
        }
    }
}