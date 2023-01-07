using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Controllers
{
    /// <summary>
    /// Controller de recebimento das requisições da classe principal.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PrincipalController : ControllerBase
    {
        private readonly IServicesApiPrincipal _servicesApiPrincipal;

        public PrincipalController(IServicesApiPrincipal servicesApiPrincipal)
        {
            _servicesApiPrincipal = servicesApiPrincipal;
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todos os bancos de dados.
        /// </summary>
        /// <returns>Lista de descrição de todos os bancos de dados.</returns>
        [HttpGet]
        [Route("/ListagemBancosDeDados")]
        public List<string> ListagemBancosDeDados()
        {
            return _servicesApiPrincipal.ListagemBancosDeDados();
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todos os estilos de formulários.
        /// </summary>
        /// <returns>Lista de descrição de todos os estilos de formulários.</returns>
        [HttpGet]
        [Route("/ListagemEstiloFormulario")]
        public List<string> ListagemEstiloFormulario()
        {
            return _servicesApiPrincipal.ListagemEstiloFormulario();
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todas as IDE de desenvolvimento.
        /// </summary>
        /// <returns>Lista de descrição de todas as IDE de desenvolvimento.</returns>
        [HttpGet]
        [Route("/ListagemIdeDesenvolvimento")]
        public List<string> ListagemIdeDesenvolvimento()
        {
            return _servicesApiPrincipal.ListagemIdeDesenvolvimento();
        }

        [HttpPost]
        [Route("/ListagemDescricaoTabelas")]
        public List<string> ListagemBancosDeDados(GeraClasse geraClasse)
        {
            return null;
        }
    }
}