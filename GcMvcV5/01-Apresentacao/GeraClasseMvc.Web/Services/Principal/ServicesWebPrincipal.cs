using GeraClasseMvc.Web.Services.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GeraClasseMvc.Web.Services
{
    /// <summary>
    /// Entidade ServicesWebPrincipal referente aos utilitários da classe principal.
    /// </summary>
    public class ServicesWebPrincipal : IServicesWebPrincipal
    {
        /// <summary>
        /// Propriedade de Injeção de dependência para IConfiguration.
        /// </summary>
        private readonly IConfiguration _configuration;
        /// <summary>
        /// Propriedade de Injeção de dependência para ILinksApi.
        /// </summary>
        private readonly ILinks _links;
        /// <summary>
        /// Propriedade que contém o nome da aplicação.
        /// </summary>
        public string NomeVersaoAplicacao { get; set; }
        /// <summary>
        /// Propriedade que contém o nome da aplicação.
        /// </summary>
        public string NomeAplicacao { get; set; }
        /// <summary>
        /// Propriedade que contém o ano versão da aplicação.
        /// </summary>
        public string AnoVersaoAplicacao { get; set; }
        /// <summary>
        /// Propriedade que contém a informação do TextArea.
        /// </summary>
        public string InformacaoTextArea { get; set; }
        /// <summary>
        /// Listagem da IDE de Desenvolvimento.
        /// </summary>
        public List<SelectListItem> ListaDeIdeDesenvolvimento { get; set; }
        /// <summary>
        /// Listagem do Estilo do Formulário.
        /// </summary>
        public List<SelectListItem> ListaDeEstiloFormulario { get; set; }
        /// <summary>
        /// Listagem do Banco de Dados.
        /// </summary>
        public List<SelectListItem> ListaDeBancoDeDados { get; set; }

        public ServicesWebPrincipal(IConfiguration configuration, ILinks links)
        {
            _configuration = configuration;
            _links = links;

            this.NomeAplicacao = CarregarPropriedadeNomeAplicacao();
            this.NomeVersaoAplicacao = CarregarPropriedadeNomeVersaoAplicacao();
            this.AnoVersaoAplicacao = CarregarPropriedadeAnoVersaoAplicacao();
            this.InformacaoTextArea = CarregarPropriedadeInformacaoTextArea();
        }

        #region Carregar Nome da Aplicacao.
        public string CarregarPropriedadeNomeAplicacao() => _configuration["GeraClasseMvc:NomeAplicacao"];
        #endregion Carregar Nome da Aplicacao

        #region Carregar Ano Versão Aplicacao.
        public string CarregarPropriedadeAnoVersaoAplicacao() => DateTime.Now.Year.ToString();
        #endregion Carregar Ano Versão Aplicacao.

        #region Carregar Nome da Versão Aplicacão.
        public string CarregarPropriedadeNomeVersaoAplicacao() => _configuration["GeraClasseMvc:NomeVersaoAplicacao"];
        #endregion Carregar Nome da Versão Aplicacão.

        #region Carregar Informação TextArea.
        public string CarregarPropriedadeInformacaoTextArea()
        {
            return "This program generates 'MVC' standard class files for the 'Delphi', 'Lazarus' and '.NET' Development Ide, from a text file containing the metadata of one or more tables.\n" +
                   "It is based on GeraClasseDelphi version 6.0. The difference is that it generates the files according to the 'MVC' project pattern,\n" +
                   "generating the Dao, Model, Controller and View files in corresponding folders.Views, Normal and Mdi style forms are created.\n\n" +

                   "Important:\n\n" +

                   "01. Font formatting obeys Delphis automatic formatter with default values, except:\n" +
                   "Right margin = 135\n" +
                   "Indent case contents = True\n\n" +

                   "02. For Views, there is a problem with accentuation in the display of dialog messages in Lazarus\n" +
                   "Adjust the Encoding of the code editor.\n" +
                   "Right click in code editor > File Settings > Encoding > select UTF-8 with BOM\n\n" +

                   "03. Version for Visual Studio in date 30.07.2022\n\n" +

                   "04. New version generate class Web in 12.10.2022";
        }
        #endregion Carregar Informação TextArea.

        #region Carregar Propriedade Lista Banco de Dados.
        public async Task CarregarPropriedadeListaBancoDeDados()
        {
            var listaObjetos = await _links.CarregaObjetos("BancosDeDados");
            this.ListaDeBancoDeDados = CarregaObjetosSelectListItem(listaObjetos);
        }
        #endregion Carregar Propriedade Lista Banco de Dados.

        #region Carregar Propriedade Lista Estilo Formulário.
        public async Task CarregarPropriedadeListaEstiloFormulario()
        {
            var listaObjetos = await _links.CarregaObjetos("EstiloFormulario");
            this.ListaDeEstiloFormulario = CarregaObjetosSelectListItem(listaObjetos);
        }
        #endregion Carregar Propriedade Lista Estilo Formulário.

        #region Carregar Propriedade Lista IDE Desenvolvimento.
        public async Task CarregarPropriedadeListaIdeDesenvolvimento()
        {
            var listaObjetos = await _links.CarregaObjetos("IdeDesenvolvimento");
            this.ListaDeIdeDesenvolvimento = CarregaObjetosSelectListItem(listaObjetos);
        }
        #endregion Carregar Propriedade Lista IDE Desenvolvimento.

        #region Retorna Descrição das Tabelas.
        public async Task<List<string>> RetornaDescricaoTabelas(object objeto)
        {
            return await _links.RetornaDescricaoTabelas(objeto);
        }
        #endregion Retorna Descrição das Tabelas.

        #region Carregar Lista de items da IDE de Desenvolvimento, Estilo do Formulário e Banco de Dados.
        public List<SelectListItem> CarregaObjetosSelectListItem(List<string> items)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                if (items != null && items.Count > 0)
                {
                    for (int i = 1; i < items.Count; i++)
                    {
                        if (!string.IsNullOrEmpty(items[i]))
                        {
                            lista.Add(new SelectListItem()
                            {
                                Value = items[i].Replace(" ", "").ToLower(),
                                Text = items[i],
                                Selected = (i > 0 && i == 1)
                            });
                        }
                    }
                }
                else
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = "Sem Valor".Replace(" ", "").ToLower(),
                        Text = "Sem Valor",
                        Selected = true
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }
        #endregion Carregar Lista de items da IDE de Desenvolvimento, Estilo do Formulário e Banco de Dados.
    }
}