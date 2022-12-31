using GeraClasseMvc.Api.Models;
using System.Threading.Tasks;

namespace GeraClasseMvc.Api.Services.Interfaces
{
    /// <summary>
    /// Interface IUtilsMvcApiPrincipal.
    /// </summary>

    public interface IUtilsMvcApiPrincipal
    {
        /// <summary>
        /// Método para Retornar a Descrição das Tabelas.
        /// </summary>
        Task<GeraClasse> RetornaDescricaoTabelas(string baseURL, GeraClasse metadata);
    }
}