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

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["NomeDaAplicacao"] = _utils.NomeDaAplicacao;
            ViewData["TituloVersaoAplicacao"] = _utils.NomeDaVersaoAplicacao;
            ViewData["AnoVersaoAplicacao"] = _utils.AnoVersaoAplicacao;

            return View("Principal");
        }

        [HttpPost]
        public IActionResult Principal()
        {
            //Aqui chamar o httpclient e dependendo do retorno chamar a proxima view;
            return null;
        }
    }
}