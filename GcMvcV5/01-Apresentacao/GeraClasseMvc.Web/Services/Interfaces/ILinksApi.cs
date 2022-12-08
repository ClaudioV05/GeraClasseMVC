using GeraClasseMvc.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services.Interfaces
{
    public interface ILinksApi
    {
        Task<IEnumerable<string>> DescricaoBancosDeDados();
        Task<IEnumerable<string>> DescricaoEstiloFormulario();
        Task<IEnumerable<string>> DescricaoIdeDesenvolvimento();
    }
}