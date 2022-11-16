using GeraClasseMvc.Api.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GeraClasseMvc.Api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {
        /// <summary>
        /// Método responsável por retornar as tabelas que serão utilizadas no gera classe.
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public Metadata Principal(Metadata metadata)
        {
            return metadata;
        }
    }
}