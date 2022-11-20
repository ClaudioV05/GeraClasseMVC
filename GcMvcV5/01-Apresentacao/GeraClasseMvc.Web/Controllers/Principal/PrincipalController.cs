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

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet, ActionName("GeraDadosPrincipais")]
        public IActionResult GeraDadosPrincipais()
        {
            PrincipalViewModel principalViewModel = new PrincipalViewModel();
            try
            {
                CarregaDadosTemplateGeral();
                
                principalViewModel.InformacaoTextArea = _utilsWeb.InformacaoTextArea;
                principalViewModel.ListaDeIdeDesenvolvimento = _utilsWeb.ListaDeIdeDesenvolvimento;
                principalViewModel.ListaDeEstiloFormulario = _utilsWeb.ListaDeEstiloFormulario;
                principalViewModel.ListaDeBancoDeDados = _utilsWeb.ListaDeBancoDeDados;
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
        [HttpPost, ActionName("GeraDadosPrincipais")]
        public IActionResult GeraDadosPrincipais(PrincipalViewModel principalViewModel)
        {
            Metadata metadata = new Metadata();

            try
            {
                metadata.BancodeDados.IdTipoBancodeDados = _metodosGenericos.RetornaTipoBancoDeDados(principalViewModel.BancoDeDados);
                //    metadata.ScriptMetadata = principalViewModel.ArquivoMetadata;
                //    //metadata = _utilsApi.RetornaDescricaoTabelas("http://localhost:3001/Principal", metadata);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            return null;
        }

        #region Métodos Generícos
        private void CarregaDadosTemplateGeral()
        {
            ViewData["NomeAplicacao"] = _utilsWeb.NomeAplicacao;
            ViewData["NomeVersaoAplicacao"] = _utilsWeb.NomeVersaoAplicacao;
            ViewData["AnoVersaoAplicacao"] = _utilsWeb.AnoVersaoAplicacao;
        }
        #endregion Métodos Generícos
    }
}