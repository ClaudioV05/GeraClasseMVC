using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Controllers.Principal
{
    public class PrincipalController : Controller
    {
        private readonly IUtils _utils;

        public PrincipalController(IUtils utils)
        {
            _utils = utils;
        }

        public IActionResult Index()
        {
            ViewData["Titulo"] = _utils.NomeDaAplicacao;

            return View("Principal");
        }
    }
}