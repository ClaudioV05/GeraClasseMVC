using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Web.Models;
using GeraClasseMvc.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;

namespace GeraClasseMvc.Web.Controllers.Principal
{
    public class PrincipalController : Controller
    {
        private readonly IUtilsMvcWebPrincipal _utilsWeb;
        private readonly ILinksApi _linksApi;
        public PrincipalController(IUtilsMvcWebPrincipal utilsWeb, ILinksApi linksapi)
        {
            _utilsWeb = utilsWeb;
            _linksApi = linksapi;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [ActionName("GeraDadosPrincipais")]
        public IActionResult GeraDadosPrincipais()
        {
            PrincipalViewModel principalViewModel = new PrincipalViewModel();
            try
            {
                CarregaDadosTemplateGeral();

                principalViewModel.InformacaoTextArea = _utilsWeb.InformacaoTextArea;
                principalViewModel.ListaDeBancoDeDados = _utilsWeb.ListaDeBancoDeDados;
                principalViewModel.ListaDeEstiloFormulario = _utilsWeb.ListaDeEstiloFormulario;
                principalViewModel.ListaDeIdeDesenvolvimento = _utilsWeb.ListaDeIdeDesenvolvimento;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return View("Principal", principalViewModel);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="principalViewModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ActionName("GeraDadosPrincipais")]
        public IActionResult GeraDadosPrincipais(PrincipalViewModel principalViewModel)
        {
            Metadata metadata = new Metadata();

            try
            {
                //metadata.BancodeDados.IdTipoBancodeDados = _metodosGenericos.TipoBancoDeDados(principalViewModel.BancoDeDados);
                var aux = _linksApi.RetornaTipoBancoDeDados(principalViewModel.BancoDeDados);
                metadata.ScriptMetadata = principalViewModel.ArquivoMetadados;
                /*metadata = _utilsApi.RetornaDescricaoTabelas("http://localhost:3001/Principal", metadata);*/
            }
            catch (Exception ex)
            {
               Redirect(ex.Message);
            }

            return null;
        }

        #region Métodos Genéricos
        private void CarregaDadosTemplateGeral()
        {
            ViewData["NomeAplicacao"] = _utilsWeb.NomeAplicacao;
            ViewData["NomeVersaoAplicacao"] = _utilsWeb.NomeVersaoAplicacao;
            ViewData["AnoVersaoAplicacao"] = _utilsWeb.AnoVersaoAplicacao;
        }
        #endregion Métodos Genéricos
    }
}