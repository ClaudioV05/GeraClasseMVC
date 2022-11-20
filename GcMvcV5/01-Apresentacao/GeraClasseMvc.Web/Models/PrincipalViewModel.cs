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
        public string ArquivoMetadados { get; set; }
        public string InformacaoTextArea { get; set; }
        public string BancoDeDados { get; set; }
        public IEnumerable<SelectListItem> ListaDeIdeDesenvolvimento { get; set; }
        public IEnumerable<SelectListItem> ListaDeEstiloFormulario { get; set; }
        public IEnumerable<SelectListItem> ListaDeBancoDeDados { get; set; }
    }
}