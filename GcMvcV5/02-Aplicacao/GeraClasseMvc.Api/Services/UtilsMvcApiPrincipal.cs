using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Api.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace GeraClasseMvc.Api.Services
{
    public class UtilsMvcApiPrincipal : IUtilsMvcApiPrincipal
    {
        public async Task<Metadata> RetornaDescricaoTabelas(string baseURL, Metadata metadata)
        {
            // Pegar o de macorrai
            return null;
        }
    }
}