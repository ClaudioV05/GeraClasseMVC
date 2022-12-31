using GeraClasseMvc.Web.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services
{
    public class LinksApi : ILinksApi
    {
        private readonly JsonSerializerOptions _options;
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

        #region Métodos para o Formulário Principal
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
                            lista = await JsonSerializer.DeserializeAsync<List<string>>(resultadoApi, _options);
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

        #endregion Métodos para o Formulário Principal.

        #region Métodos para o Formulário Escolhe Tabelas.
        // Aqui para formulário de escolha de tabela.
        #endregion Métodos para o Formulário Escolhe Tabelas.

        #region Métodos para o Formulário Escolhe Campos.
        // Aqui para formulário de campos.
        #endregion Métodos para o Formulário Escolhe Campos.
    }
}