using GeraClasseMvc.Api.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using GeraClasseMvc.Api.Models;

namespace GeraClasseMvc.Api.Controllers
{
    /// <summary>
    /// Classe básica do form Principal.
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : Controller
    {
        private readonly IMetodosGenericos _metodosGenericos;
        public PrincipalController(IMetodosGenericos metodosGenericos)
        {
            _metodosGenericos = metodosGenericos;
        }

        /// <summary>
        /// Método responsável por retornar o tipo do banco de dados.
        /// </summary>
        /// <param name="tipoBancoDeDados"></param>
        /// <returns>Tipo do banco de dados</returns>
        [HttpGet]
        [Route("/RetornaTipoBancoDeDados")]
        public TipoBancodeDados RetornaTipoBancoDeDados(string tipoBancoDeDados)
        {
            return _metodosGenericos.RetornaTipoBancoDeDados(tipoBancoDeDados);
        }
    }
}