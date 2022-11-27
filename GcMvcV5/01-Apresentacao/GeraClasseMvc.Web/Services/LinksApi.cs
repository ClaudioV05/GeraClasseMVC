using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services
{
    public class LinksApi : ILinksApi
    {
        private const string _BASEURI = "/Principal";
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;

        public LinksApi(IHttpClientFactory httpClientFactory)
        {
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _httpClientFactory = httpClientFactory;
        }

        public async Task<TipoBancodeDados> TipoBancoDeDados(string bancoDeDados)
        {
            var client = _httpClientFactory.CreateClient("GeraClasseApi");

            using (var response = await client.GetAsync(_BASEURI))
            {
                if (response.IsSuccessStatusCode)
                {
                    var apiResponse = await response.Content.ReadAsStringAsync();
                }
            }
            return TipoBancodeDados.NaoDefinido;
        }
    }
}
