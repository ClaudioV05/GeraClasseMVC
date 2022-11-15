using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GeraClasseMvc.Web
{
    /// <summary>
    /// Classe básica referente aos utilitários da classe principal.
    /// </summary>
    public interface IUtilsPrincipal
    {
        /// <summary>
        /// Descrição do nome da versão da aplicação.
        /// </summary>
        string NomeDaVersaoAplicacao { get; set; }

        /// <summary>
        /// Descrição do nome da aplicação.
        /// </summary>
        string NomeDaAplicacao { get; set; }

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
        IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }

        /// <summary>
        /// Lista de Estilos do Formulário.
        /// </summary>
        IEnumerable<SelectListItem> EstiloFormularioListItem { get; set; }

        /// <summary>
        /// Lista de Banco(s) de Dados.
        /// </summary>
        IEnumerable<SelectListItem> BancoDeDadosListItem { get; set; }

        /// <summary>
        /// Método para carregar o nome da versão da aplicação.
        /// </summary>
        /// <returns></returns>
        string CarregarNomeDaVersaoAplicacao();

        /// <summary>
        /// Método para carregar o nome da aplicação.
        /// </summary>
        string CarregarNomeDaAplicacao();

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
        IEnumerable<SelectListItem> CarregarListItem(string[] items);
    }
}