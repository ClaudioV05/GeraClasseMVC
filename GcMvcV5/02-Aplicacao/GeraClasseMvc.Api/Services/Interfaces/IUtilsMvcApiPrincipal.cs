using GeraClasseMvc.Api.Models;
using System.Threading.Tasks;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    public interface IUtilsMvcApiPrincipal
    {
        Task<Metadata> RetornaDescricaoTabelas(string baseURL, Metadata metadata);
    }
}