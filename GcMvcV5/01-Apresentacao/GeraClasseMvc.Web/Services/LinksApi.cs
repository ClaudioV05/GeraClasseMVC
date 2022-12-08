using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using System.Net;

namespace GeraClasseMvc.Web.Services
{
    public class LinksApi : ILinksApi
    {
        private readonly JsonSerializerOptions _options;
        private readonly IHttpClientFactory _httpClientFactory;
        public LinksApi(IHttpClientFactory httpClientFactory)
        {
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _httpClientFactory = httpClientFactory;
        }

        #region Formulário Principal.
        public async Task<IEnumerable<string>> DescricaoBancosDeDados()
        {
            var httpClient = NovaInstacia();
            IEnumerable<string> items = null;
            try
            {
                using (var resposta = await httpClient.GetAsync("DescricaoBancosDeDados"))
                {
                    if (resposta.StatusCode == HttpStatusCode.OK)
                    {
                        var resultadoApi = await resposta.Content.ReadAsStreamAsync();
                        items = await JsonSerializer.DeserializeAsync<IEnumerable<string>>(resultadoApi, _options);
                    }
                }
            }
            catch (Exception)
            {
                items = null;
            }

            return items;
        }

        public async Task<IEnumerable<string>> DescricaoEstiloFormulario()
        {
            var httpClient = NovaInstacia();
            IEnumerable<string> items = null;
            try
            {
                using (var resposta = await httpClient.GetAsync("DescricaoEstiloFormulario"))
                {
                    if (resposta.StatusCode == HttpStatusCode.OK)
                    {
                        var resultadoApi = await resposta.Content.ReadAsStreamAsync();
                        items = await JsonSerializer.DeserializeAsync<IEnumerable<string>>(resultadoApi, _options);
                    }
                }
            }
            catch (Exception)
            {
                items = null;
            }

            return items;
        }

        public async Task<IEnumerable<string>> DescricaoIdeDesenvolvimento()
        {
            var httpClient = NovaInstacia();
            IEnumerable<string> items = null;
            try
            {
                using (var resposta = await httpClient.GetAsync("DescricaoIdeDesenvolvimento"))
                {
                    if (resposta.StatusCode == HttpStatusCode.OK)
                    {
                        var resultadoApi = await resposta.Content.ReadAsStreamAsync();
                        items = await JsonSerializer.DeserializeAsync<IEnumerable<string>>(resultadoApi, _options);
                    }
                }
            }
            catch (Exception)
            {
                items = null;
            }

            return items;
        }
        #endregion Formulário Principal.

        #region Formulário Escolhe Tabelas.
        // Aqui para formulário de escolha de tabela.
        #endregion Formulário Escolhe Tabelas.

        #region Formulário Escolhe Campos.
        // Aqui para formulário de campos.
        #endregion Formulário Escolhe Campos.

        private HttpClient NovaInstacia() => _httpClientFactory.CreateClient("GeraClasseApi");

    }
}