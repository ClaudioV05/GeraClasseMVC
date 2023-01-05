using GeraClasseMvc.Api.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services.Interfaces
{
    /// <summary>
    /// Interface ILinksApi Responsável pela comunicação entre o Front-End e o API.
    /// </summary>
    public interface ILinksApi
    {
        /// <summary>
        /// Método genérico para realizar chamadas via httpclient e carregar as propriedade de listagem.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>Listagem com o nome dos objetos a serem carregados</returns>
        Task<List<string>> CarregaObjetos(string tipo);
        /// <summary>
        /// Método responsável por retornar todas as tabelas contidas no metadata.
        /// </summary>
        /// <param name="geraClasse"></param>
        /// <returns>Listage dos nomes das tabelas.</returns>
        Task<List<string>> RetornaDescricaoTabelas(GeraClasse geraClasse);
    }
}