using GeraClasseMvc.Api.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace GeraClasseMvc.Web
{
    public interface IUtils
    {
        string NomeDaVersaoAplicacao { get; set; }

        string NomeDaAplicacao { get; set; }

        string AnoVersaoAplicacao { get; set; }

        IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }

    }
}