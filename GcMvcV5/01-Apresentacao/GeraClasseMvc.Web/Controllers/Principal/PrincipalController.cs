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
        private readonly IServicesPrincipal _servicesPrincipal;
        private readonly IConversor _conversor;

        public PrincipalController(IServicesPrincipal servicesPrincipal, IConversor conversor)
        {
            _servicesPrincipal = servicesPrincipal;
            _conversor = conversor;
        }

        [HttpGet]
        [ActionName("GeraDadosPrincipais")]
        public async Task<IActionResult> GeraDadosPrincipais()
        {
            PrincipalViewModel principalViewModel = new PrincipalViewModel();
            try
            {
                await _servicesPrincipal.CarregarPropriedadeListaBancoDeDados();
                await _servicesPrincipal.CarregarPropriedadeListaEstiloFormulario();
                await _servicesPrincipal.CarregarPropriedadeListaIdeDesenvolvimento();

                CarregarDadosViewModelListagem(ref principalViewModel);
                CarregaDadosViewModelTemplateGeral();

                principalViewModel.InformacaoTextArea = _servicesPrincipal.InformacaoTextArea;
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
                await _servicesPrincipal.RetornaDescricaoTabelas(new GeraClasse()
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
            ViewData["NomeAplicacao"] = _servicesPrincipal.NomeAplicacao;
            ViewData["NomeVersaoAplicacao"] = _servicesPrincipal.NomeVersaoAplicacao;
            ViewData["AnoVersaoAplicacao"] = _servicesPrincipal.AnoVersaoAplicacao;
        }

        private void CarregarDadosViewModelListagem(ref PrincipalViewModel principalViewModel)
        {
            principalViewModel.ListaDeBancoDeDados = _servicesPrincipal.ListaDeBancoDeDados;
            principalViewModel.ListaDeEstiloFormulario = _servicesPrincipal.ListaDeEstiloFormulario;
            principalViewModel.ListaDeIdeDesenvolvimento = _servicesPrincipal.ListaDeIdeDesenvolvimento;
        }
        #endregion Métodos Genéricos
    }
}