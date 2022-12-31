using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web
{
    /// <summary>
    /// Interface IUtilsMvcWebPrincipal referente aos utilitários da classe principal.
    /// </summary>
    public interface IUtilsMvcWebPrincipal
    {
        /// <summary>
        /// Descrição do nome da versão da aplicação.
        /// </summary>
        string NomeVersaoAplicacao { get; set; }
        /// <summary>
        /// Descrição do nome da aplicação.
        /// </summary>
        string NomeAplicacao { get; set; }
        /// <summary>
        /// Descrição do ano corrente da versão da aplicação.
        /// </summary>
        string AnoVersaoAplicacao { get; set; }
        /// <summary>
        /// Texto Informativo da versão da aplicação.
        /// </summary>
        string InformacaoTextArea { get; set; }
        /// <summary>
        /// Lista de Ide(s) de Desenvolvimento.
        /// </summary>
        List<SelectListItem> ListaDeIdeDesenvolvimento { get; set; }
        /// <summary>
        /// Lista de Estilos do Formulário.
        /// </summary>
        List<SelectListItem> ListaDeEstiloFormulario { get; set; }
        /// <summary>
        /// Lista de Banco(s) de Dados.
        /// </summary>
        List<SelectListItem> ListaDeBancoDeDados { get; set; }
        /// <summary>
        /// Método para carregar o nome da versão da aplicação.
        /// </summary>
        /// <returns></returns>
        string CarregarPropriedadeNomeVersaoAplicacao();
        /// <summary>
        /// Método para carregar o nome da aplicação.
        /// </summary>
        string CarregarPropriedadeNomeAplicacao();
        /// <summary>
        /// Método para carregar o ano corrente da versão da aplicação.
        /// </summary>
        /// <returns></returns>
        string CarregarPropriedadeAnoVersaoAplicacao();
        /// <summary>
        /// Método para carregar o texto Informativo da versão da aplicação.
        /// </summary>
        string CarregarPropriedadeInformacaoTextArea();
        /// <summary>
        /// Listagem do Banco de Dados.
        /// </summary>
        Task CarregarPropriedadeListaBancoDeDados();
        /// <summary>
        /// Listagm do Estilo do Formulário.
        /// </summary>
        Task CarregarPropriedadeListaEstiloFormulario();
        /// <summary>
        /// Listagem da IDE de Desenvolvimento.
        /// </summary>
        Task CarregarPropriedadeListaIdeDesenvolvimento();
        /// <summary>
        /// Método generico para carregar a lista de items de IDE de desenvolvimento, estilo do formulário e banco de dados.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        List<SelectListItem> CarregaObjetosSelectListItem(List<string> items);
    }
}