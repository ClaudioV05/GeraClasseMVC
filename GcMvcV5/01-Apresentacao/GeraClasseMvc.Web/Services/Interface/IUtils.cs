using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GeraClasseMvc.Web
{
    public interface IUtils
    {
        /// <summary>
        /// Nome da versão da aplicação.
        /// </summary>
        string NomeDaVersaoAplicacao { get; set; }

        /// <summary>
        /// Nome da aplicação.
        /// </summary>
        string NomeDaAplicacao { get; set; }

        /// <summary>
        /// Ano da versão da aplicação.
        /// </summary>
        string AnoVersaoAplicacao { get; set; }

        /// <summary>
        /// Lista de Ide de Desenvolvimento.
        /// </summary>
        IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }

        /// <summary>
        /// Lista de Estilo do Formulário.
        /// </summary>
        IEnumerable<SelectListItem> EstiloFormularioListItem { get; set; }

        /// <summary>
        /// Lista de Banco de Dados.
        /// </summary>
        IEnumerable<SelectListItem> BancoDeDadosListItem { get; set; }
    }
}