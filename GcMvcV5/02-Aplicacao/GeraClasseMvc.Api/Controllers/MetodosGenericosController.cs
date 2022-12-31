using GeraClasseMvc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Controllers
{
    /// <summary>
    /// Classe básica do form MetodosGenericosController.
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class MetodosGenericosController : ControllerBase
    {
        private readonly IMetodosGenericos _metodosGenericos;

        public MetodosGenericosController(IMetodosGenericos metodosGenericos)
        {
            _metodosGenericos = metodosGenericos;
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todos os bancos de dados.
        /// </summary>
        /// <returns>Lista de descrição de todos os bancos de dados.</returns>
        [HttpGet]
        [Route("/ListagemBancosDeDados")]
        public List<string> ListagemBancosDeDados()
        {
            return _metodosGenericos.ListagemBancosDeDados();
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todos os estilos de formulários.
        /// </summary>
        /// <returns>Lista de descrição de todos os estilos de formulários.</returns>
        [HttpGet]
        [Route("/ListagemEstiloFormulario")]
        public List<string> ListagemEstiloFormulario()
        {
            return _metodosGenericos.ListagemEstiloFormulario();
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todas as IDE de desenvolvimento.
        /// </summary>
        /// <returns>Lista de descrição de todas as IDE de desenvolvimento.</returns>
        [HttpGet]
        [Route("/ListagemIdeDesenvolvimento")]
        public List<string> ListagemIdeDesenvolvimento()
        {
            return _metodosGenericos.ListagemIdeDesenvolvimento();
        }
    }
}