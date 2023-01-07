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
    /// Entidade Links Responsável pela comunicação entre o Front-End e o API do GeraClasse.
    /// </summary>
    public sealed class Links : ILinks
    {
        /// <summary>
        /// Propriedade de Injeção de dependência para JsonSerializerOptions.
        /// </summary>
        private readonly JsonSerializerOptions _jsonOptions;
        /// <summary>
        /// Propriedade de Injeção de dependência para IHttpClientFactory.
        /// </summary>
        private readonly IHttpClientFactory _httpClient;
 
        #region Constantes de configuração.
        private const string NOME_HTTPCLIENT = "GeraClasseApi";
        private const string MIME_TYPE_DEFAULT = "application/json";
        #endregion Constantes de configuração.

        #region Endpoint da classe Principal.
        private const string ACTION_LISTAGEM = "Listagem";
        private const string ACTION_LISTAGEM_TABELAS = "ListagemDescricaoTabelas";
        #endregion Endpoint da classe Principal.

        public Links(IHttpClientFactory httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
        }

        #region Métodos para o Formulário Principal.
        public async Task<List<string>> CarregaObjetos(string endpoint)
        {
            var httpClient = InicializaInstacia();
            var lista = new List<string>();

            try
            {
                if (httpClient != null)
                {
                    using var resposta = await httpClient.GetAsync($"{ACTION_LISTAGEM}{endpoint}", HttpCompletionOption.ResponseHeadersRead);

                    if (resposta.StatusCode == HttpStatusCode.OK)
                    {
                        var resultadoApi = await resposta.Content.ReadAsStreamAsync();
                        lista = await System.Text.Json.JsonSerializer.DeserializeAsync<List<string>>(resultadoApi, _jsonOptions);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"Erro: {ex.Message}");
            }
            return lista;
        }

        public async Task<List<string>> RetornaDescricaoTabelas(object objeto)
        {
            var httpClient = InicializaInstacia();
            var lista = new List<string>();

            try
            {
                if (httpClient != null && objeto != null)
                {
                    using var resposta = await httpClient.PostAsync(ACTION_LISTAGEM_TABELAS, ObjetoParaStringContent(httpClient, objeto));

                    if (resposta.StatusCode == HttpStatusCode.OK)
                    {
                        var resultadoApi = await resposta.Content.ReadAsStreamAsync();
                        lista = await System.Text.Json.JsonSerializer.DeserializeAsync<List<string>>(resultadoApi, _jsonOptions);
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

        #region Métodos.

        #region Inicializa Instâcia.
        public HttpClient InicializaInstacia() => _httpClient.CreateClient(NOME_HTTPCLIENT);
        #endregion Inicializa Instâcia.

        #region Objeto Para StringContent.
        public StringContent ObjetoParaStringContent(HttpClient httpClient, object objeto)
        {
            // limpa o header.
            httpClient.DefaultRequestHeaders.Accept.Clear();
            // Incluir o cabeçalho Accept que será envia na requisição.
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(MIME_TYPE_DEFAULT));
            // Serialização do  objeto.
            var jsonContent = JsonConvert.SerializeObject(objeto);
            // Criação de uma nova instância de StringContent.
            var contentString = new StringContent(jsonContent, Encoding.UTF8, MIME_TYPE_DEFAULT);
            contentString.Headers.ContentType = new MediaTypeHeaderValue(MIME_TYPE_DEFAULT);

            return contentString;
        }
        #endregion Objeto Para StringContent.

        #endregion Métodos.
    }
}