using Microsoft.Extensions.Configuration;
using System;

namespace GeraClasseMvc.Web.Services
{
    public class Utils : IUtils
    {
        public Utils(IConfiguration configuration)
        {
            this.NomeDaVersaoAplicacao = configuration["GeraClasseMvc:NomeDaVersaoAplicacao"];
            this.NomeDaAplicacao = configuration["GeraClasseMvc:NomeDaAplicacao"];
            this.AnoVersaoAplicacao = DateTime.Now.Year.ToString();
        }

        public string NomeDaVersaoAplicacao { get; set; }

        public string NomeDaAplicacao { get; set; }

        public string AnoVersaoAplicacao { get; set; }
    }
}