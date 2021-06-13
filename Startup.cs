using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ProgaWeb3TP.src.Entidades;
using ProgaWeb3TP.src.Repositorios;
using Repositorios;
using Servicios;

namespace ProgaWeb3TP
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
                options.Cookie.Name = ".MiAPP.Session";
                
            });

            services.AddControllersWithViews();
            services.AddSingleton<IServicioArticulo, ServicioArticulo>();
            services.AddSingleton<IRepositorioArticulo, RepositorioArticulo>();
            services.AddScoped<IServicioCliente, ServicioCliente>();
            services.AddScoped<IServicioUsuario, ServicioUsuario>();
            services.AddScoped<IRepositorioCliente, RepositorioClienteEF>();
            services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            services.AddSingleton<IServicioPedido, ServicioPedido>();
            services.AddSingleton<IRepositorioPedido, RepositorioPedido>();
            services.AddDbContext<_20211CTPContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("_20211CTPContext")));
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

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Login}/{action=Login}/{id?}");
            });
        }
    }
}
