using GeraClasseMvc.Api.Models;
using System.Threading.Tasks;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    public interface IUtilsMvcApiPrincipal
    {
        Task<GeraClasse> RetornaDescricaoTabelas(string baseURL, GeraClasse metadata);
    }
}