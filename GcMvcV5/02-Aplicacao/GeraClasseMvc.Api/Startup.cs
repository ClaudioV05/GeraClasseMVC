using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.IO;

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

                if (File.Exists(diretorioArquivoXml))
                {
                    c.IncludeXmlComments(diretorioArquivoXml);
                }
                else
                {
                    File.Create(diretorioArquivoXml).Dispose();
                    c.IncludeXmlComments(diretorioArquivoXml);
                }
            });

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            // Habilita o middleware para servir o Swagger gerado como um endpoint  JSON
            app.UseSwagger();

            //Registra o gerador Swagger definindo um ou mais documentos Swagger 
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Gerador de classes MVC");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}