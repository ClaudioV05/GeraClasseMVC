using GeraClasseMvc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GeraClasseMvc.Api.Controllers
{
    /// <summary>
    /// Classe básica do form Principal.
    /// </summary>
    [ApiController]
    [Route("[controller]")]
    [Produces("application/json")]
    public class PrincipalController : ControllerBase
    {
        public PrincipalController() { }

        [HttpPost]
        [Route("/ListagemDescricaoTabelas")]
        public List<string> ListagemBancosDeDados(GeraClasse geraClasse)
        {
            return null;
        }
    }
}