using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Web.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Utils.ConversorBase64.Interfaces;

namespace GeraClasseMvc.Web.Controllers.Principal
{
    public class PrincipalController : Controller
    {
        private readonly IUtilsMvcWebPrincipal _utilsWeb;
        private readonly IConversor _conversor;
        public PrincipalController(IUtilsMvcWebPrincipal utilsWeb, IConversor conversor)
        {
            _utilsWeb = utilsWeb;
            _conversor = conversor;
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
        public async Task<IActionResult> GeraDadosPrincipais(PrincipalViewModel principalViewModel)
        {
            try
            {
                await _utilsWeb.RetornaDescricaoTabelas(new GeraClasse()
                {
                    MetadadosBase64 = _conversor.CodificaParaBase64(principalViewModel.Metadados),
                    BancodeDadosBase64 = _conversor.CodificaParaBase64(principalViewModel.TipoBancoDeDados),
                    EstiloFormularioBase64 = _conversor.CodificaParaBase64(principalViewModel.TipoEstiloFormulario),
                    IdeDesenvolvimentoBase64 = _conversor.CodificaParaBase64(principalViewModel.TipoIdeDesenvolvimento)
                });

                // Version se vai carregar uma var list e passar pra Model.
                // Colocar aqui um redirect para a proxima view Redirect(ex.Message);
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