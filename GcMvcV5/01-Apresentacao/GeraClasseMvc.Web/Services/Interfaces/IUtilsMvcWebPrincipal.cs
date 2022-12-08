using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web
{
    /// <summary>
    /// Classe básica referente aos utilitários da classe principal.
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
        IEnumerable<SelectListItem> ListaDeIdeDesenvolvimento { get; set; }

        /// <summary>
        /// Lista de Estilos do Formulário.
        /// </summary>
        IEnumerable<SelectListItem> ListaDeEstiloFormulario { get; set; }

        /// <summary>
        /// Lista de Banco(s) de Dados.
        /// </summary>
        IEnumerable<SelectListItem> ListaDeBancoDeDados { get; set; }

        /// <summary>
        /// Método para carregar o nome da versão da aplicação.
        /// </summary>
        /// <returns></returns>
        string CarregarNomeVersaoAplicacao();

        /// <summary>
        /// Método para carregar o nome da aplicação.
        /// </summary>
        string CarregarNomeAplicacao();

        /// <summary>
        /// Método para carregar o ano corrente da versão da aplicação.
        /// </summary>
        /// <returns></returns>
        string CarregarAnoVersaoAplicacao();

        /// <summary>
        /// Método para carregar o texto Informativo da versão da aplicação.
        /// </summary>
        string CarregarInformacaoTextArea();

        /// <summary>
        /// Método generico para carregar a lista de items de IDE de desenvolvimento, estilo do formulário e banco de dados.
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        IEnumerable<SelectListItem> CarregarListaDeItems(Task<IEnumerable<string>> items);
    }
}