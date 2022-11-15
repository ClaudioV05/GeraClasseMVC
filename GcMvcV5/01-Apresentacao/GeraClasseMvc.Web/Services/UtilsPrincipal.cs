using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace GeraClasseMvc.Web.Services
{
    public class UtilsPrincipal : IUtilsPrincipal
    {
        private readonly IConfiguration _configuration;

        public UtilsPrincipal(IConfiguration configuration)
        {
            _configuration = configuration;

            this.NomeDaVersaoAplicacao = CarregarNomeDaVersaoAplicacao();
            this.NomeDaAplicacao = CarregarNomeDaAplicacao();
            this.AnoVersaoAplicacao = CarregarAnoVersaoAplicacao();
            this.InformacaoTextArea = CarregarInformacaoTextArea();
            this.IdeDesenvolvimentoListItem = CarregarListItem(new[] { "Delphi", "Lazarus", "Visual Studio" });
            this.EstiloFormularioListItem = CarregarListItem(new[] { "Normal", "MDI", "Windows Form", "HTML" });
            this.BancoDeDadosListItem = CarregarListItem(new[] { "SQL Puro", "Firebird" });
        }

        public string NomeDaVersaoAplicacao { get; set; }

        public string NomeDaAplicacao { get; set; }

        public string AnoVersaoAplicacao { get; set; }

        public string InformacaoTextArea { get; set; }

        public IEnumerable<SelectListItem> IdeDesenvolvimentoListItem { get; set; }

        public IEnumerable<SelectListItem> EstiloFormularioListItem { get; set; }

        public IEnumerable<SelectListItem> BancoDeDadosListItem { get; set; }

        #region Carregar Lista de items da Ide de Desenvolvimento, Estilo do Formulário e Banco de Dados.
        public IEnumerable<SelectListItem> CarregarListItem(string[] items)
        {
            List<SelectListItem> lista = new List<SelectListItem>();
            try
            {
                if (items.Length > 0)
                {
                    for (int i = 0; i < items.Length; i++)
                    {
                        if (!string.IsNullOrEmpty(items[i]))
                        {
                            lista.Add(new SelectListItem() { Value = items[i].Replace(" ", "").ToLower(), Text = items[i] });
                        }
                    }
                }
                else
                {
                    lista.Add(new SelectListItem() { Value = "Sem Valor".Replace(" ", "").ToLower(), Text = "Sem Valor" });
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return lista;
        }
        #endregion Carregar Lista de items da Ide de Desenvolvimento, Estilo do Formulário e Banco de Dados.

        #region CarregarAnoVersaoAplicacao
        public string CarregarAnoVersaoAplicacao() => DateTime.Now.Year.ToString();
        #endregion CarregarAnoVersaoAplicacao

        #region CarregarNomeDaVersaoAplicacao
        public string CarregarNomeDaVersaoAplicacao() => _configuration["GeraClasseMvc:NomeDaVersaoAplicacao"];
        #endregion CarregarNomeDaVersaoAplicacao

        #region CarregarNomeDaAplicacao
        public string CarregarNomeDaAplicacao() => _configuration["GeraClasseMvc:NomeDaAplicacao"];
        #endregion CarregarNomeDaAplicacao

        #region CarregarInformacaoTextArea
        public string CarregarInformacaoTextArea()
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
        #endregion CarregarInformacaoTextArea
    }
}