using GeraClasseMvc.Api.Models;
using GeraClasseMvc.Web.Services.Interfaces;
using System;
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
            _options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
            _httpClientFactory = httpClientFactory;
        }

        #region Formulário Principal.
        public async Task<TipoBancodeDados> RetornaTipoBancoDeDados(string bancoDeDados)
        {
            var client = _httpClientFactory.CreateClient("GeraClasseApi");
            try
            {
                using (var response = await client.GetAsync("RetornaTipoBancoDeDados?tipoBancoDeDados=" + bancoDeDados))
                {
                    if (response.IsSuccessStatusCode)
                    {
                        var apiResponse = await response.Content.ReadAsStringAsync();
                    }
                    else
                    {
                        throw new Exception(response.ReasonPhrase);
                    }
                }
            }
            catch (Exception)
            {
                return TipoBancodeDados.NaoDefinido;
            }
            return TipoBancodeDados.NaoDefinido;
        }
        #endregion Formulário Principal.

        #region Formulário Escolhe Tabelas.
        // Aqui para formulário de escolha de tabela.
        #endregion Formulário Escolhe Tabelas.

        #region Formulário Escolhe Campos.
        // Aqui para formulário de campos.
        #endregion Formulário Escolhe Campos.

        #region Métodos Genéricos.
        // Aqui para os métodos genéricos.
        #endregion Métodos Genéricos.
    }
}