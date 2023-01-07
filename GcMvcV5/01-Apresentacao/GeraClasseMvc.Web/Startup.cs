using GeraClasseMvc.Web.Services;
using GeraClasseMvc.Web.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using Utils.ConversorBase64.Interfaces;
using Utils.ConversorBase64.Services;

namespace GeraClasseMvc.Web
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

            // Adiciona o IHttpClientFactory e os serviços relacionados ao container DI.
            services.AddHttpClient("GeraClasseApi", c => c.BaseAddress = new Uri(Configuration["Uri:GeraClasseMvcApi"]));

            services.AddScoped<ILinks, Links>();
            services.AddScoped<IServicesWebPrincipal, ServicesWebPrincipal>();
            #region Injeção de dependência de Utils.
            services.AddScoped<IConversor, Conversor>();
            #endregion Injeção de dependência de Utils.
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "{controller=Principal}/{action=GeraDadosPrincipais}");
            });
        }
    }
}