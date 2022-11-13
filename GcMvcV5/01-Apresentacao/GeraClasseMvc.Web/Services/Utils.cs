using Microsoft.Extensions.Configuration;

namespace GeraClasseMvc.Web.Services
{
    public class Utils : IUtils
    {
        public Utils(IConfiguration configuration)
        {
            this.NomeDaAplicacao = configuration["GeraClasseMvc:NomeDaAplicacao"];
        }

        public string NomeDaAplicacao { get; set; }
    }
}