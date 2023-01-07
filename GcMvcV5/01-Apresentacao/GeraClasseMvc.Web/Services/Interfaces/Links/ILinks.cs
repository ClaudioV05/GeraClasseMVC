using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services.Interfaces
{
    /// <summary>
    /// Interface ILinks Responsável pela comunicação entre o Front-End e o API do GeraClasse.
    /// </summary>
    public interface ILinks
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
        /// <param name="objeto"></param>
        /// <returns>Listage dos nomes das tabelas.</returns>
        Task<List<string>> RetornaDescricaoTabelas(object objeto);
        /// <summary>
        /// Inicializa Instâcia de HTTPClIENT.
        /// </summary
        HttpClient InicializaInstacia();
        /// <summary>
        /// Converte um objeto baseado em classe para o tipo StringContent.
        /// </summary>
        StringContent ObjetoParaStringContent(HttpClient httpClient, object objeto);
    }
}