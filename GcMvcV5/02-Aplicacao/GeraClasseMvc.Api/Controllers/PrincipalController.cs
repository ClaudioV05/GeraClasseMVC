using Microsoft.AspNetCore.Mvc;

namespace GeraClasseMvc.Api.Controllers
{
    /// <summary>
    /// Classe básica do form Principal.
    /// </summary>
    [Produces("application/json")]
    [ApiController]
    [Route("[controller]")]
    public class PrincipalController : ControllerBase
    {
        public PrincipalController() { }
    }
}