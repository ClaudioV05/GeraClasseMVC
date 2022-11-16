using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Api.Services.Interfaces;
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
        private readonly IUtilsMvcWebPrincipal _utilsWeb;

        private readonly IUtilsMvcApiPrincipal _utilsApi;

        private readonly IMetodosGenericos _metodosGenericos;

        public PrincipalController(IUtilsMvcWebPrincipal utilsWeb, IUtilsMvcApiPrincipal utilsApi, IMetodosGenericos metodosGenericos)
        {
            _utilsWeb = utilsWeb;
            _utilsApi = utilsApi;
            _metodosGenericos = metodosGenericos;
        }

        [HttpGet]
        public IActionResult Principal()
        {
            ViewData["NomeDaAplicacao"] = _utilsWeb.NomeDaAplicacao;
            ViewData["TituloVersaoAplicacao"] = _utilsWeb.NomeDaVersaoAplicacao;
            ViewData["AnoVersaoAplicacao"] = _utilsWeb.AnoVersaoAplicacao;

            var principalViewModel = new PrincipalViewModel()
            {
                InformacaoTextArea = _utilsWeb.InformacaoTextArea,
                IdeDesenvolvimentoListItem = _utilsWeb.IdeDesenvolvimentoListItem,
                EstiloFormularioListItem = _utilsWeb.EstiloFormularioListItem,
                BancoDeDadosListItem = _utilsWeb.BancoDeDadosListItem
            };

            return View("Principal", principalViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Principal(PrincipalViewModel principalViewModel)
        {
            Metadata metadata = new Metadata();

            try
            {
                metadata.BancodeDados.Id = _metodosGenericos.RetornaTipoBancoDeDados(principalViewModel.BancoDeDados);
                metadata.ScriptMetadata = principalViewModel.ArquivoMetadata;
                //metadata = _utilsApi.RetornaDescricaoTabelas("http://localhost:3001/Principal", metadata);
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        #region Métodos
        // aqui ficarão os métodos de chegda e de tratamento de dados.
        #endregion Métodos
    }
}