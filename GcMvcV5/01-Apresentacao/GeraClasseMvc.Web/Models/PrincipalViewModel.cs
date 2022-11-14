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
        public IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }
    }
}