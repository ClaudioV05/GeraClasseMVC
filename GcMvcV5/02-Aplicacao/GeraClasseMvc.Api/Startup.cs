using GeraClasseMvc.Api.Services;
using GeraClasseMvc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using System.IO;
using System.Reflection;

namespace GeraClasseMvc.Api
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
            services.AddScoped<IServicesApiPrincipal, ServicesApiPrincipal>();

            ConfiguraSwagger(services);

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            // Habilita o middleware para servir o Swagger gerado como um endpoint JSON.
            app.UseSwagger();

            // Registra o gerador Swagger definindo um ou mais documentos Swagger.
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerador de classes MVC"));

            app.UseEndpoints(endpoints => endpoints.MapControllers());
        }
        #region Métodos.

        #region Configura Swagger.
        private void ConfiguraSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GeraClasseMvcApi",
                    Description = "Gerador de classes MVC",
                    TermsOfService = new Uri("https://claudiomildo.net/terms"),
                    Contact = new OpenApiContact
                    {
                        Name = "Claudiomildo",
                        Email = "claudiomildo@hotmail.com",
                        Url = new Uri("https://www.claudiomildo.net"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Informações sobre a licença.",
                        Url = new Uri("https://claudiomildo.net/license"),
                    }
                });

                var diretorioArquivoXml = Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml");

                if (!File.Exists(diretorioArquivoXml))
                {
                    File.Create(diretorioArquivoXml).Dispose();
                }
                else
                {
                    c.IncludeXmlComments(diretorioArquivoXml);
                }
            });
        }
        #endregion Configura Swagger.

        #endregion Métodos.
    }
}