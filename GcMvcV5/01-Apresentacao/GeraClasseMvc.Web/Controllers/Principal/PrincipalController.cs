using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Controllers.Principal
{
    public class PrincipalController : Controller
    {
        private readonly IUtilsMvcWebPrincipal _utilsWeb;
        public PrincipalController(IUtilsMvcWebPrincipal utilsWeb)
        {
            _utilsWeb = utilsWeb;
        }

        [HttpGet]
        [ActionName("GeraDadosPrincipais")]
        public async Task<IActionResult> GeraDadosPrincipais()
        {
            PrincipalViewModel principalViewModel = new PrincipalViewModel();
            try
            {
                await _utilsWeb.CarregarPropriedadeListaBancoDeDados();
                await _utilsWeb.CarregarPropriedadeListaEstiloFormulario();
                await _utilsWeb.CarregarPropriedadeListaIdeDesenvolvimento();

                CarregarDadosViewModelListagem(ref principalViewModel);
                CarregaDadosViewModelTemplateGeral();

                principalViewModel.InformacaoTextArea = _utilsWeb.InformacaoTextArea;
            }
            catch (Exception ex)
            {
                throw new Exception("Erro: " + ex.Message);
            }

            return View("Principal", principalViewModel);
        }

        [HttpPost]
        [ActionName("GeraDadosPrincipais")]
        public IActionResult GeraDadosPrincipais(PrincipalViewModel principalViewModel)
        {
            GeraClasse metadata = new GeraClasse();

            try
            {
                //metadata.BancodeDados.IdTipoBancodeDados = _metodosGenericos.TipoBancoDeDados(principalViewModel.BancoDeDados);
                //var aux = _linksApi.RetornaTipoBancoDeDados(principalViewModel.BancoDeDados);
                metadata.Metadados = principalViewModel.Metadados;
                /*metadata = _utilsApi.RetornaDescricaoTabelas("http://localhost:3001/Principal", metadata);*/
            }
            catch (Exception ex)
            {
               Redirect(ex.Message);
            }

            return null;
        }

        #region Métodos Genéricos
        private void CarregaDadosViewModelTemplateGeral()
        {
            ViewData["NomeAplicacao"] = _utilsWeb.NomeAplicacao;
            ViewData["NomeVersaoAplicacao"] = _utilsWeb.NomeVersaoAplicacao;
            ViewData["AnoVersaoAplicacao"] = _utilsWeb.AnoVersaoAplicacao;
        }

        private void CarregarDadosViewModelListagem(ref PrincipalViewModel principalViewModel)
        {
            principalViewModel.ListaDeBancoDeDados = _utilsWeb.ListaDeBancoDeDados;
            principalViewModel.ListaDeEstiloFormulario = _utilsWeb.ListaDeEstiloFormulario;
            principalViewModel.ListaDeIdeDesenvolvimento = _utilsWeb.ListaDeIdeDesenvolvimento;
        }
        #endregion Métodos Genéricos
    }
}