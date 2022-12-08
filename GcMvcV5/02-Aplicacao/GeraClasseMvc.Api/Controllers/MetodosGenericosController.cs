using GeraClasseMvc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeraClasseMvc.Api.Controllers
{
    /// <summary>
    /// Classe básica do form MetodosGenericosController.
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class MetodosGenericosController : Controller
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
        [Route("/DescricaoBancosDeDados")]
        public IEnumerable<string> DescricaoBancosDeDados()
        {
            IEnumerable<string> descricaoDosBancosDeDados = null;
            try
            {
                descricaoDosBancosDeDados = _metodosGenericos.DescricaoBancosDeDados();
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return descricaoDosBancosDeDados;
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todos os estilos de formulários.
        /// </summary>
        /// <returns>Lista de descrição de todos os estilos de formulários.</returns>
        [HttpGet]
        [Route("/DescricaoEstiloFormulario")]
        public IEnumerable<string> DescricaoEstiloFormulario()
        {
            IEnumerable<string> descricaoDosEstiloFormulario = null;
            try
            {
                descricaoDosEstiloFormulario = _metodosGenericos.DescricaoEstiloFormulario();
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return descricaoDosEstiloFormulario;
        }

        /// <summary>
        /// Método responsável por retornar lista de descrição de todas as IDE de desenvolvimento.
        /// </summary>
        /// <returns>Lista de descrição de todas as IDE de desenvolvimento.</returns>
        [HttpGet]
        [Route("/DescricaoIdeDesenvolvimento")]
        public IEnumerable<string> DescricaoIdeDesenvolvimento()
        {
            IEnumerable<string> descricaoDasIdeDesenvolvimento = null;
            try
            {
                descricaoDasIdeDesenvolvimento = _metodosGenericos.DescricaoIdeDesenvolvimento();
            }
            catch (Exception)
            {
                //return StatusCode(StatusCodes.Status500InternalServerError);
            }

            return descricaoDasIdeDesenvolvimento;
        }
    }
}
