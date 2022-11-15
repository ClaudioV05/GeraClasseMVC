using GeraClasseMvc.Api.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Models
{
    public class PrincipalViewModel
    {
        public string ArquivoMetadata { get; set; }

        public string InformacaoTextArea { get; set; }

        public IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }

        public IEnumerable<SelectListItem> EstiloFormularioListItem { get; set; }

        public IEnumerable<SelectListItem> BancoDeDadosListItem { get; set; }
    }
}