using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Web.Services.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services
{
    /// <summary>
    /// Entidade LinksApi.
    /// </summary>
    public class LinksApi : ILinksApi
    {
        /// <summary>
        /// Propriedade de Injeção de dependência para JsonSerializerOptions.
        /// </summary>
        private readonly JsonSerializerOptions _options;
        /// <summary>
        /// Propriedade de Injeção de dependência para IHttpClientFactory.
        /// </summary>
        private readonly IHttpClientFactory _httpClientFactory;

        public LinksApi(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        private HttpClient InicializaInstacia()
        {
            return _httpClientFactory.CreateClient("GeraClasseApi");
        }

        #region Métodos para o Formulário Principal.
        public async Task<List<string>> CarregaObjetos(string NomeEndpoint)
        {
            var httpClient = InicializaInstacia();
            var lista = new List<string>();

            try
            {
                if (httpClient != null)
                {
                    using (var resposta = await httpClient.GetAsync($"Listagem{NomeEndpoint}", HttpCompletionOption.ResponseHeadersRead))
                    {
                        if (resposta.StatusCode == HttpStatusCode.OK)
                        {
                            var resultadoApi = await resposta.Content.ReadAsStreamAsync();
                            lista = await System.Text.Json.JsonSerializer.DeserializeAsync<List<string>>(resultadoApi, _options);
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            return lista;
        }

        public async Task<List<string>> RetornaDescricaoTabelas(GeraClasse geraClasse)
        {
            var httpClient = InicializaInstacia();
            var lista = new List<string>();

            try
            {
                if (httpClient != null)
                {
                    //limpa o header
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    //incluir o cabeçalho Accept que será envia na requisição
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    var jsonContent = JsonConvert.SerializeObject(geraClasse);
                    var contentString = new StringContent(jsonContent, Encoding.UTF8, "application/json");
                    contentString.Headers.ContentType = new MediaTypeHeaderValue("application/json");

                    using (var resposta = await httpClient.PostAsync("ListagemDescricaoTabelas", contentString))
                    {
                        if (resposta.StatusCode == HttpStatusCode.OK)
                        {
                            var resultadoApi = await resposta.Content.ReadAsStreamAsync();
                            lista = await System.Text.Json.JsonSerializer.DeserializeAsync<List<string>>(resultadoApi, _options);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            return null;
        }
        #endregion Métodos para o Formulário Principal.

        #region Métodos para o Formulário Escolhe Tabelas.
        // Aqui para formulário de escolha de tabela.
        #endregion Métodos para o Formulário Escolhe Tabelas.

        #region Métodos para o Formulário Escolhe Campos.
        // Aqui para formulário de campos.
        #endregion Métodos para o Formulário Escolhe Campos.
    }
}