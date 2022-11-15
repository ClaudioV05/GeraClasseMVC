using GeraClasseMvc.Web.Models;
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
        private readonly IUtilsPrincipal _utils;

        public PrincipalController(IUtilsPrincipal utils)
        {
            _utils = utils;
        }

        [HttpGet]
        public IActionResult Principal()
        {
            ViewData["NomeDaAplicacao"] = _utils.NomeDaAplicacao;
            ViewData["TituloVersaoAplicacao"] = _utils.NomeDaVersaoAplicacao;
            ViewData["AnoVersaoAplicacao"] = _utils.AnoVersaoAplicacao;

            var principalViewModel = new PrincipalViewModel()
            {
                InformacaoTextArea = _utils.InformacaoTextArea,
                IdeDesenvolvimentoListItem = _utils.IdeDesenvolvimentoListItem,
                EstiloFormularioListItem = _utils.EstiloFormularioListItem,
                BancoDeDadosListItem = _utils.BancoDeDadosListItem
            };

            return View("Principal", principalViewModel);
        }

        [HttpPost]
        public IActionResult Principal(PrincipalViewModel principalViewModel)
        {
            //Aqui chamar o httpclient e dependendo do retorno chamar a proxima view;
            return null;
        }

        #region Métodos
        // aqui ficarão os métodos de chegda e de tratamento de dados.
        #endregion Métodos
    }
}