using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services.Interfaces
{
    public interface ILinksApi
    {
        /// <summary>
        /// Método genérico para realizar chamadas via httpclient e carregar as propriedade de listagem.
        /// </summary>
        /// <param name="tipo"></param>
        /// <returns>Listagem com o nome dos objetos a serem carregados</returns>
        Task<List<string>> CarregaObjetos(string tipo);
    }
}